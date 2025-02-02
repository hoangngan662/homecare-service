<script>
import axios from 'axios';
import Toast from '../Common/Toast.vue';

export default {
    name: "Service",
    components: {
        Toast
    },
    data() {
        return {
            serviceTypes: [],
            pageNumber: 1,
            pageSize: 6,
            totalCount: 0,
            searchValue: '',
            isSuccessVisible: false,
            isErrorVisible: false,
            successMessage: '',
            errorMessage: '',
        };
    },
    computed: {
        totalPages() {
            return Math.ceil(this.totalCount / this.pageSize);
        },
        visiblePages() {
            const pages = [];
            const totalVisiblePages = 5;
            const halfWindow = Math.floor((totalVisiblePages - 3) / 2);

            if (this.totalPages <= totalVisiblePages) {
                for (let i = 1; i <= this.totalPages; i++) {
                    pages.push(i);
                }
            } else {
                pages.push(1);

                if (this.pageNumber > halfWindow + 2) {
                    pages.push('...');
                }

                const startPage = Math.max(2, this.pageNumber - halfWindow);
                const endPage = Math.min(this.totalPages - 1, this.pageNumber + halfWindow);

                for (let i = startPage; i <= endPage; i++) {
                    pages.push(i);
                }

                if (endPage < this.totalPages - 1) {
                    pages.push('...');
                }

                pages.push(this.totalPages);
            }

            return pages;
        },
        startRecord() {
            return (this.pageNumber - 1) * this.pageSize + 1;
        },
        endRecord() {
            return Math.min(this.pageNumber * this.pageSize, this.totalCount);
        },
    },
    methods: {        
        async fetchServiceTypes() {
            try {
                const response = await axios.get(`https://localhost:7072/api/service/service-types/search`, {
                    params: {
                        searchValue: this.searchValue,
                        pageNumber: this.pageNumber,
                        pageSize: this.pageSize
                    }
                });

                this.serviceTypes = response.data.items;

                const backendUrl = 'https://localhost:7072'; // Cập nhật với địa chỉ của backend nếu cần

                // Cập nhật đường dẫn hình ảnh cho từng service type
                this.serviceTypes = this.serviceTypes.map(serviceType => {
                    if (serviceType.image) {
                        serviceType.image = `${backendUrl}${serviceType.image}`;
                    }
                    return serviceType;
                });

                this.totalCount = response.data.totalCount;

            } catch (error) {
                this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
            }
        },
        async submitSearch() {
            try {
                this.pageNumber = 1;
                this.fetchServiceTypes();
            } catch (error) {
            }
        },
        showSuccessToast(message) {
            this.successMessage = message;
            this.isSuccessVisible = true;
            setTimeout(this.hideSuccessToast, 3000);
        },
        hideSuccessToast() {
            this.isSuccessVisible = false;
        },
        showErrorToast(message) {
            this.errorMessage = message;
            this.isErrorVisible = true;
            setTimeout(this.hideErrorToast, 3000);
        },
        hideErrorToast() {
            this.isErrorVisible = false;
        },
        prevPage() {
            if (this.pageNumber > 1) {
                this.pageNumber--;
                this.fetchServiceTypes();
            }
        },
        nextPage() {
            if (this.pageNumber < this.totalPages) {
                this.pageNumber++;
                this.fetchServiceTypes();
            }
        },
        goToPage(page) {
            if (page !== '...') {
                this.pageNumber = page;
                this.fetchServiceTypes();
            }
        },
        formatPrice(value) {
            return new Intl.NumberFormat('vi-VN').format(value);
        },
    },
    mounted() {
        this.fetchServiceTypes();
    }
}
</script>

<template>
    <Toast v-if="isSuccessVisible" :message="successMessage" :isVisible="isSuccessVisible" @close="hideSuccessToast" />
    <Toast v-if="isErrorVisible" :message="errorMessage" :isVisible="isErrorVisible" @close="hideErrorToast" />

    <div class="relative p-4 overflow-x-auto shadow-md sm:rounded-lg">
        <!-- Breadcrumb -->
        <nav class="flex px-5 py-3 text-gray-700 border border-gray-200 rounded-lg bg-gray-50 dark:bg-gray-800 dark:border-gray-700"
            aria-label="Breadcrumb">
            <ol class="inline-flex items-center space-x-1 md:space-x-2 rtl:space-x-reverse">
                <li class="inline-flex items-center">
                    <a href="/"
                        class="inline-flex items-center text-sm font-medium text-gray-700 hover:text-blue-600 dark:text-gray-400 dark:hover:text-white">
                        <svg class="w-3 h-3 me-2.5" aria-hidden="true" xmlns="http://www.w3.org/2000/svg"
                            fill="currentColor" viewBox="0 0 20 20">
                            <path
                                d="m19.707 9.293-2-2-7-7a1 1 0 0 0-1.414 0l-7 7-2 2a1 1 0 0 0 1.414 1.414L2 10.414V18a2 2 0 0 0 2 2h3a1 1 0 0 0 1-1v-4a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v4a1 1 0 0 0 1 1h3a2 2 0 0 0 2-2v-7.586l.293.293a1 1 0 0 0 1.414-1.414Z" />
                        </svg>
                        Trang chủ
                    </a>
                </li>
                <li>
                    <div class="flex items-center">
                        <svg class="rtl:rotate-180 block w-3 h-3 mx-1 text-gray-400 " aria-hidden="true"
                            xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 6 10">
                            <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                d="m1 9 4-4-4-4" />
                        </svg>
                        <a href="/service"
                            class="ms-1 text-sm font-medium text-gray-700 hover:text-blue-600 md:ms-2 dark:text-gray-400 dark:hover:text-white">Dịch
                            vụ</a>
                    </div>
                </li>
            </ol>
        </nav>
        <div class="flex flex-col items-center">
            <h1
                class="mt-4 mb-4 text-3xl font-semibold leading-none text-gray-900 md:text-5xl lg:text-3xl dark:text-white">
                Dịch vụ của chúng tôi</h1>

            <form class="w-full px-6" @submit.prevent="submitSearch">
                <label for="default-search"
                    class="mb-2 text-sm font-medium text-gray-900 sr-only dark:text-white">Tìm kiếm</label>
                <div class="relative">
                    <div class="absolute inset-y-0 start-0 flex items-center ps-3 pointer-events-none">
                        <svg class="w-4 h-4 text-gray-500 dark:text-gray-400" aria-hidden="true"
                            xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 20 20">
                            <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                d="m19 19-4-4m0-7A7 7 0 1 1 1 8a7 7 0 0 1 14 0Z" />
                        </svg>
                    </div>
                    <input type="search" v-model="searchValue"
                        class="block w-full p-4 ps-10 text-sm text-gray-900 border border-gray-300 rounded-lg bg-gray-50 focus:ring-blue-500 focus:border-blue-500 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                        placeholder="Tìm kiếm dịch vụ" />
                    <button type="submit"
                        class="text-white absolute end-2.5 bottom-2.5 bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-4 py-2 dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">
                        Tìm kiếm
                    </button>
                </div>
            </form>
            <div class="p-2 grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
                <div v-for="service in serviceTypes" :key="service.id"
                    class=" w-full max-w-sm bg-white border border-gray-200 rounded-lg shadow dark:bg-gray-800 dark:border-gray-700">
                    <img class="rounded-t-lg h-64" :src="service.image" alt="product image" />
                    <div class="px-5 pb-5">
                        <h5 class="text-lg font-semibold text-gray-900 dark:text-white mt-2">
                            {{ service.name }} <!-- Assuming each service has a name -->
                        </h5>
                        <div class="flex items-center justify-between">
                            <span class="text-xl font-bold text-gray-900 dark:text-white">
                                Từ {{ formatPrice(service.sessionPrice) }} VNĐ</span>
                            <!-- Assuming price is a string -->
                            <a :href="`/service/${service.id}`"
                                class="text-gray-900 bg-white border border-gray-300 focus:outline-none hover:bg-gray-100 focus:ring-4 focus:ring-gray-100 font-medium rounded-lg text-sm px-5 py-2.5 dark:bg-gray-800 dark:text-white dark:border-gray-600 dark:hover:bg-gray-700 dark:hover:border-gray-600 dark:focus:ring-gray-700">
                                Xem chi tiết
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <nav class="p-2 flex items-center flex-column flex-wrap md:flex-row justify-between pt-4"
            aria-label="Table navigation">
            <span
                class="text-sm font-normal text-gray-500 dark:text-gray-400 mb-4 md:mb-0 block w-full md:inline md:w-auto">
                Hiển thị <span class="font-semibold text-gray-900 dark:text-white">{{ startRecord }}-{{ endRecord
                    }}</span> trong số
                <span class="font-semibold text-gray-900 dark:text-white">{{ totalCount }}</span> kết quả
            </span>
            <ul class="inline-flex -space-x-px rtl:space-x-reverse text-sm h-8">
                <li v-if="pageNumber > 1">
                    <button @click="prevPage"
                        class="flex items-center justify-center px-3 h-8 ms-0 leading-tight text-gray-500 bg-white border border-gray-300 rounded-s-lg hover:bg-gray-100 hover:text-gray-700 dark:bg-gray-800 dark:border-gray-700 dark:text-gray-400 dark:hover:bg-gray-700 dark:hover:text-white">
                        Previous
                    </button>
                </li>
                <li v-for="page in visiblePages" :key="page">
                    <button @click="goToPage(page)"
                        :class="['flex items-center justify-center px-3 h-8 leading-tight', page === pageNumber ? 'text-blue-600 border-gray-300 bg-blue-50 hover:bg-blue-100 hover:text-blue-700 dark:border-gray-700 dark:bg-gray-700 dark:text-white' : 'text-gray-500 bg-white border border-gray-300 hover:bg-gray-100 hover:text-gray-700 dark:bg-gray-800 dark:border-gray-700 dark:text-gray-400 dark:hover:bg-gray-700 dark:hover:text-white']">
                        {{ page }}
                    </button>
                </li>
                <li v-if="pageNumber < totalPages">
                    <button @click="nextPage"
                        class="flex items-center justify-center px-3 h-8 leading-tight text-gray-500 bg-white border border-gray-300 rounded-e-lg hover:bg-gray-100 hover:text-gray-700 dark:bg-gray-800 dark:border-gray-700 dark:text-gray-400 dark:hover:bg-gray-700 dark:hover:text-white">
                        Next
                    </button>
                </li>
            </ul>
        </nav>
    </div>
</template>
