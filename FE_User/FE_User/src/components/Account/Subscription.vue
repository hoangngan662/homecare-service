<script>
import axios from 'axios';
import BottomNav from './BottomNav.vue';
import Toast from '../Common/Toast.vue';
export default {
    name: "Subscription",
    components: {
        BottomNav,
        Toast
    },
    data() {
        return {
            subscriptions: [],
            pageNumber: 1,
            pageSize: 10,
            totalCount: 0,
            selectedStatus: 0,
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
        }
    },
    methods: {
        async fetchSubscriptions() {
            try {
                const patientId = localStorage.getItem('id');
                
                const response = await axios.get('https://localhost:7072/api/subscription/patient-status', {
                    params: {
                        patientId: patientId,
                        status: this.selectedStatus,
                        pageNumber: this.pageNumber,
                        pageSize: this.pageSize,
                    }
                });
                
                this.subscriptions = response.data.items;
                this.totalCount = response.data.totalCount;
            } catch (error) {
                this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
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
                this.fetchSubscriptions();
            }
        },
        nextPage() {
            if (this.pageNumber < this.totalPages) {
                this.pageNumber++;
                this.fetchSubscriptions();
            }
        },
        goToPage(page) {
            if (page !== '...') {
                this.pageNumber = page;
                this.fetchSubscriptions();
            }
        },
        loadData() {
            this.fetchSubscriptions();
        }
    },
    mounted() {
        this.fetchSubscriptions();
    }
}
</script>
<template>
    <Toast v-if="isSuccessVisible" :message="successMessage" :isVisible="isSuccessVisible" @close="hideSuccessToast" />
    <Toast v-if="isErrorVisible" :message="errorMessage" :isVisible="isErrorVisible" @close="hideErrorToast" />

    <div class="relative m-4 p-4 overflow-x-auto shadow-md sm:rounded-lg min-h-screen">
        <h3 class="text-2xl font-extrabold dark:text-white">Đăng ký dịch vụ</h3>
        <br />
        <div class="flex items-center justify-end mb-4">
            <label class="block mr-2 text-sm font-medium text-gray-900 dark:text-white">Trạng thái</label>
            <select v-model="selectedStatus" @change="loadData"
                class="bg-gray-50 w-auto border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
                <option value="0">Chưa kích hoạt</option>
                <option value="1">Đã kích hoạt</option>
                <option value="2">Hoàn thành</option>
                <option value="3">Hủy</option>
            </select>
        </div>
        <table class="w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400">
            <thead class="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
                <tr>
                    <th scope="col" class="px-6 py-3">
                        STT
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Bệnh nhân
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Gói dịch vụ
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Ngày đăng ký
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Trạng thái
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Xử lý
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(sub, index) in subscriptions" :key="sub.id"
                    class="bg-white border-b dark:bg-gray-800 dark:border-gray-700 hover:bg-gray-50 dark:hover:bg-gray-600">
                    <td class="px-6 py-4">
                        {{ index + 1 }}
                    </td>
                    <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                        {{ sub.patientFullName }}
                    </th>
                    <td class="px-6 py-4">
                        <span>{{ sub.serviceTypeName }}</span>
                        <br />
                        <span class="py-4 font-medium text-gray-900 dark:text-white">{{ sub.servicePackageName }}</span>
                    </td>
                    <td class="px-6 py-4">
                        {{ new Date(sub.subscriptionDate).toLocaleDateString('en-GB') }}
                        <br />
                        {{ new Date(sub.subscriptionDate).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' })
                        }}
                    </td>
                    <td class="px-6 py-4">
                        <span v-if="sub.status === 'Pending'"
                            class="bg-yellow-100 text-yellow-800 text-xs font-medium px-2.5 py-0.5 rounded-full dark:bg-yellow-900 dark:text-yellow-300">
                            Chưa kích hoạt
                        </span>
                        <span v-else-if="sub.status === 'Active'"
                            class="bg-green-100 text-green-800 text-xs font-medium px-2.5 py-0.5 rounded-full dark:bg-green-900 dark:text-green-300">
                            Đã kích hoạt
                        </span>
                        <span v-else-if="sub.status === 'Completed'"
                            class="bg-blue-100 text-blue-800 text-xs font-medium px-2.5 py-0.5 rounded-full dark:bg-blue-900 dark:text-blue-300">
                            Hoàn thành
                        </span>
                        <span v-else-if="sub.status === 'Cancelled'"
                            class="bg-red-100 text-red-800 text-xs font-medium px-2.5 py-0.5 rounded-full dark:bg-red-900 dark:text-red-300">
                            Hủy
                        </span>
                        <span v-else
                            class="bg-gray-100 text-gray-800 text-xs font-medium px-2.5 py-0.5 rounded-full dark:bg-gray-900 dark:text-gray-300">
                            Default
                        </span>
                    </td>
                    <td class="px-6 py-4">
                        <a :href="`/subscription/${sub.id}`"
                            class="font-medium text-blue-600 dark:text-blue-500 hover:underline">Chi tiết</a>
                    </td>
                </tr>
            </tbody>
        </table>
        <nav class="flex items-center flex-column flex-wrap md:flex-row justify-between pt-4"
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
        <BottomNav />
    </div>
</template>