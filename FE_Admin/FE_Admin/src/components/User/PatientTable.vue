<script>
import axios from 'axios';

export default {
    name: 'PatientTable',
    data() {
        return {
            patients: [],
            pageNumber: 1,
            pageSize: 4,
            totalCount: 0,
        };
    },
    computed: {
        totalPages() {
            return Math.ceil(this.totalCount / this.pageSize);
        },
        visiblePages() {
            const pages = [];
            const totalVisiblePages = 5; // Total pages to display (including first and last)
            const halfWindow = Math.floor((totalVisiblePages - 3) / 2); // Pages on each side of current page

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
        async fetchPatients() {            
            try {
                const response = await axios.get('https://localhost:7072/api/user/roles/3', {
                    params: {
                        pageNumber: this.pageNumber,
                        pageSize: this.pageSize,
                    }
                });

                this.patients = response.data.items;
                this.totalCount = response.data.totalCount;
            } catch (error) {
                console.error("There was an error fetching the patients:", error);
            }
        },
        prevPage() {
            if (this.pageNumber > 1) {
                this.pageNumber--;
                this.fetchPatients();
            }
        },
        nextPage() {
            if (this.pageNumber < this.totalPages) {
                this.pageNumber++;
                this.fetchPatients();
            }
        },
        goToPage(page) {
            if (page !== '...') {
                this.pageNumber = page;
                this.fetchPatients();
            }
        }
    },
    mounted() {
        const role = localStorage.getItem('roleStaff');
        if(role != "Admin"){
            this.$router.push('/');
        }
        else{
            this.fetchPatients();
        }        
    }
};
</script>

<template>
    <div class="relative p-4 overflow-x-auto shadow-md sm:rounded-lg">
        <h3 class="text-2xl font-extrabold dark:text-white">Danh sách khách hàng</h3>
        <p class="my-4 text-sm text-gray-500">Trang danh sách khách hàng hiển thị thông tin tổng quan và cung cấp các
            chức năng quản lý, giúp dễ dàng xem chi tiết và chỉnh sửa thông tin của từng khách hàng.</p>
        <router-link to="/patient/add"
            class="flex items-center w-fit text-gray-900 bg-white border border-gray-300 focus:outline-none hover:bg-gray-100 focus:ring-4 focus:ring-gray-100 font-medium rounded-full text-sm px-5 py-2.5 me-2 mb-2 dark:bg-gray-800 dark:text-white dark:border-gray-600 dark:hover:bg-gray-700 dark:hover:border-gray-600 dark:focus:ring-gray-700">
            <svg class="w-6 h-6 text-gray-800 dark:text-white me-2" aria-hidden="true"
                xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none" viewBox="0 0 24 24">
                <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                    d="M5 12h14m-7 7V5" />
            </svg>
            Thêm
        </router-link>

        <table class="w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400">
            <thead class="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
                <tr>
                    <th scope="col" class="px-6 py-3">
                        STT
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Họ và tên
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Địa chỉ
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Email
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Số điện thoại
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Xử lý
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(patient, index) in patients" :key="patient.id"
                    class="bg-white border-b dark:bg-gray-800 dark:border-gray-700 hover:bg-gray-50 dark:hover:bg-gray-600">
                    <td class="px-6 py-4">
                        {{ index + 1 }}
                    </td>
                    <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                        {{ patient.fullname }}
                    </th>
                    <td class="px-6 py-4">
                        {{ patient.address }}
                    </td>
                    <td class="px-6 py-4">
                        {{ patient.email }}
                    </td>
                    <td class="px-6 py-4">
                        {{ patient.phoneNumber }}
                    </td>
                    <td class="px-6 py-4">
                        <a :href="`/patient/${patient.id}`"
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
                <li v-if="pageNumber > 1"> <!-- Only show if not on the first page -->
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
                <li v-if="pageNumber < totalPages"> <!-- Only show if not on the last page -->
                    <button @click="nextPage"
                        class="flex items-center justify-center px-3 h-8 leading-tight text-gray-500 bg-white border border-gray-300 rounded-e-lg hover:bg-gray-100 hover:text-gray-700 dark:bg-gray-800 dark:border-gray-700 dark:text-gray-400 dark:hover:bg-gray-700 dark:hover:text-white">
                        Next
                    </button>
                </li>
            </ul>
        </nav>
    </div>
</template>