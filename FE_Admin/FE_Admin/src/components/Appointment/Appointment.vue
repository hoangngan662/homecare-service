<script>
import axios from 'axios';

export default {
    name: 'Appointment',
    data() {
        return {
            appointments: [],
            pageNumber: 1,
            pageSize: 10,
            totalCount: 0,
            selectedStatus: 0,
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
                const response = await axios.get('https://localhost:7072/api/appointment', {
                    params: {
                        status: this.selectedStatus,
                        pageNumber: this.pageNumber,
                        pageSize: this.pageSize,
                    }
                });
                console.log(this.appointments);

                this.appointments = response.data.items;
                this.totalCount = response.data.totalCount;
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
        <h3 class="text-2xl font-extrabold dark:text-white">Danh sách lịch hẹn</h3>
        <p class="my-4 text-sm text-gray-500">Description</p>
        <div class="flex items-center justify-between mb-4">
            <router-link to="/subscription"
                class="flex items-center w-fit text-gray-900 bg-white border border-gray-300 focus:outline-none hover:bg-gray-100 focus:ring-4 focus:ring-gray-100 font-medium rounded-full text-sm px-5 py-2.5 me-2 mb-2 dark:bg-gray-800 dark:text-white dark:border-gray-600 dark:hover:bg-gray-700 dark:hover:border-gray-600 dark:focus:ring-gray-700">
                <svg class="w-6 h-6 text-gray-800 dark:text-white me-2" aria-hidden="true"
                    xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none" viewBox="0 0 24 24">
                    <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                        d="M5 12h14m-7 7V5" />
                </svg>
                Thêm
            </router-link>
            <div class="flex items-center justify-end mb-4">
                <label class="block mr-2 text-sm font-medium text-gray-900 dark:text-white">Trạng thái</label>
                <select v-model="selectedStatus" @change="loadData"
                    class="bg-gray-50 w-auto border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
                    <option value="0">Pending</option>
                    <option value="1">Scheduled</option>
                    <option value="2">Completed</option>
                    <option value="3">Cancelled</option>
                </select>
            </div>
        </div>

        <table class="w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400">
            <thead class="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
                <tr>
                    <th scope="col" class="px-6 py-3">
                        STT
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Mã đăng ký
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Bệnh nhân
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Nhân viên
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Gói dịch vụ
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Ngày hẹn
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
                <tr v-for="(app, index) in appointments" :key="app.id"
                    class="bg-white border-b dark:bg-gray-800 dark:border-gray-700 hover:bg-gray-50 dark:hover:bg-gray-600">
                    <td class="px-6 py-4">
                        {{ index + 1 }}
                    </td>
                    <td scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                        {{ app.subscriptionId }}
                    </td>
                    <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                        {{ app.patientFullName }}
                    </th>
                    <td class="px-6 py-4">
                        {{ app.staffFullName }}
                    </td>
                    <td class="px-6 py-4">
                        <span>{{ app.serviceTypeName }}</span>
                        <br />
                        <span class="py-4 font-medium text-gray-900 dark:text-white">{{ app.servicePackageName }}</span>
                    </td>
                    <td class="px-6 py-4">
                        {{ new Date(app.appointmentDate).toLocaleDateString('en-GB') }}
                        <br />
                        {{ new Date(app.appointmentDate).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' })
                        }}
                    </td>
                    <td class="px-6 py-4">
                        {{ app.status }}
                    </td>
                    <td class="px-6 py-4">
                        <a :href="`/appointment/${app.id}`"
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
    </div>
</template>
