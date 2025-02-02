<script>
import axios from 'axios';

export default {
    name: 'Appointment',
    data() {
        return {
            appointments: [],
            pageNumber: 1,
            pageSize: 2,
            totalCount: 0,
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
        async fetchAppointments() {
            try {
                const response = await axios.get('https://localhost:7072/api/appointment/reviews', {
                    params: {
                        pageNumber: this.pageNumber,
                        pageSize: this.pageSize,
                    }
                });
                this.appointments = response.data.items;
                this.totalCount = response.data.totalCount;
                console.log(this.appointments);
            } catch (error) {
                console.error("There was an error fetching the Service Types:", error);
            }
        },
        prevPage() {
            if (this.pageNumber > 1) {
                this.pageNumber--;
                this.fetchAppointments();
            }
        },
        nextPage() {
            if (this.pageNumber < this.totalPages) {
                this.pageNumber++;
                this.fetchAppointments();
            }
        },
        goToPage(page) {
            if (page !== '...') {
                this.pageNumber = page;
                this.fetchAppointments();
            }
        },
        loadData() {
            this.fetchAppointments();
        }
    },
    mounted() {
        this.fetchAppointments();
    }
};
</script>

<template>
    <div class="relative p-4 overflow-x-auto shadow-md sm:rounded-lg">
        <h3 class="text-2xl font-extrabold dark:text-white">Danh sách đánh giá</h3>
        <p class="my-4 text-sm text-gray-500">Danh sách đánh giá các lịch hẹn của khách hàng</p>

        <table class="w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400">
            <thead class="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
                <tr>
                    <th scope="col" class="px-6 py-3">
                        STT
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Mã lịch hẹn
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Nhân viên
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Dịch vụ
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Đánh giá buổi hẹn
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Đánh giá nhân viên
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Ngày đánh giá
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(app, index) in appointments" :key="app.id"
                    class="bg-white border-b dark:bg-gray-800 dark:border-gray-700 hover:bg-gray-50 dark:hover:bg-gray-600">
                    <td class="px-6 py-4">
                        {{ index + 1 }}
                    </td>
                    <td scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                        <router-link :to="`/appointment/${app.id}`" class="font-medium text-gray-900 whitespace-nowrap dark:text-white hover:underline">
                            {{ app.id }}
                        </router-link>
                    </td>
                    <td scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                        {{ app.staffFullName }}
                    </td>
                    <td scope="row" class="px-6 py-4 ">
                        {{ app.serviceTypeName }}
                    </td>
                    <td scope="row" class="px-6 py-4">
                        <div class="flex items-center">
                            <!-- Hiển thị sao cho appointmentRating -->
                            <template v-if="app.appointmentReviewDto.appointmentRating">
                                <div class="flex items-center">
                                    <template v-for="star in 5" :key="star">
                                        <svg :class="star <= app.appointmentReviewDto.appointmentRating ? 'w-4 h-4 text-yellow-300' : 'w-4 h-4 text-gray-300 dark:text-gray-500'"
                                            aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor"
                                            viewBox="0 0 22 20">
                                            <path
                                                d="M20.924 7.625a1.523 1.523 0 0 0-1.238-1.044l-5.051-.734-2.259-4.577a1.534 1.534 0 0 0-2.752 0L7.365 5.847l-5.051.734A1.535 1.535 0 0 0 1.463 9.2l3.656 3.563-.863 5.031a1.532 1.532 0 0 0 2.226 1.616L11 17.033l4.518 2.375a1.534 1.534 0 0 0 2.226-1.617l-.863-5.03L20.537 9.2a1.523 1.523 0 0 0 .387-1.575Z" />
                                        </svg>
                                    </template>
                                </div>
                            </template>
                            <template v-else>
                                <span class="text-gray-500">Chưa có đánh giá</span>
                            </template>
                        </div>
                        <div>
                            {{ app.appointmentReviewDto.appointmentComment }}
                        </div>
                    </td>
                    <td class="px-6 py-4">
                        <div class="flex items-center">
                            <!-- Hiển thị sao cho staffRating -->
                            <template v-if="app.appointmentReviewDto.staffRating">
                                <div class="flex items-center">
                                    <template v-for="star in 5" :key="star">
                                        <svg :class="star <= app.appointmentReviewDto.staffRating ? 'w-4 h-4 text-yellow-300' : 'w-4 h-4 text-gray-300 dark:text-gray-500'"
                                            aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor"
                                            viewBox="0 0 22 20">
                                            <path
                                                d="M20.924 7.625a1.523 1.523 0 0 0-1.238-1.044l-5.051-.734-2.259-4.577a1.534 1.534 0 0 0-2.752 0L7.365 5.847l-5.051.734A1.535 1.535 0 0 0 1.463 9.2l3.656 3.563-.863 5.031a1.532 1.532 0 0 0 2.226 1.616L11 17.033l4.518 2.375a1.534 1.534 0 0 0 2.226-1.617l-.863-5.03L20.537 9.2a1.523 1.523 0 0 0 .387-1.575Z" />
                                        </svg>
                                    </template>
                                </div>
                            </template>
                            <template v-else>
                                <span class="text-gray-500">Chưa có đánh giá</span>
                            </template>
                        </div>
                        <div>
                            {{ app.appointmentReviewDto.staffComment }}
                        </div>
                    </td>
                    <td class="px-6 py-4">
                        {{ new Date(app.appointmentReviewDto.reviewDate).toLocaleDateString('en-GB') }}
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
    </div>
</template>
