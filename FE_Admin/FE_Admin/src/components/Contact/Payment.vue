<template>
    <div class="relative p-4 overflow-x-auto shadow-md sm:rounded-lg">
        <h3 class="text-2xl font-extrabold dark:text-white">Danh sách thanh toán</h3>
        <p class="my-4 text-sm text-gray-500">Payment</p>

        <table class="w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400">
            <thead class="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
                <tr>
                    <th scope="col" class="px-6 py-3">
                        STT
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Khách hàng
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Gói dịch vụ
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Phương thức
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Ngày thanh toán
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Số tiền
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(pay, index) in payments" :key="pay.id"
                    class="bg-white border-b dark:bg-gray-800 dark:border-gray-700 hover:bg-gray-50 dark:hover:bg-gray-600">
                    <td class="px-6 py-4">
                        {{ index + 1 }}
                    </td>
                    <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                        {{ pay.patientFullName }}
                    </th>
                    <td class="px-6 py-4">
                        <span>{{ pay.serviceTypeName }}</span>
                        <br />
                        <span class="py-4 font-medium text-gray-900 dark:text-white">{{ pay.servicePackageName }}</span>
                    </td>
                    <td class="px-6 py-4">
                        VNPAY
                    </td>
                    <td class="px-6 py-4">
                        {{ new Date(pay.paymentDate).toLocaleDateString('en-GB') }}
                        <br />
                        {{ new Date(pay.paymentDate).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' })
                        }}
                    </td>
                    <td class="px-6 py-4">
                        {{ formatPrice(pay.total) }}
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
<script>
import axios from 'axios';
export default{
    name: "Payment",
    data() {
        return {
            payments: [],
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
        async fetchData() {
            try {
                const response = await axios.get('https://localhost:7072/api/subscription/paid', {
                    params: {
                        pageNumber: this.pageNumber,
                        pageSize: this.pageSize,
                    }
                });

                this.payments = response.data.items;
                this.totalCount = response.data.totalCount;
            } catch (error) {
                console.error("There was an error fetching the Service Types:", error);
            }
        },
        prevPage() {
            if (this.pageNumber > 1) {
                this.pageNumber--;
                this.fetchData();
            }
        },
        nextPage() {
            if (this.pageNumber < this.totalPages) {
                this.pageNumber++;
                this.fetchData();
            }
        },
        goToPage(page) {
            if (page !== '...') {
                this.pageNumber = page;
                this.fetchData();
            }
        },
        formatDate(dateString) {
            const date = new Date(dateString);
            return date.toLocaleDateString('vi-VN', { day: '2-digit', month: '2-digit', year: 'numeric' });
        },
        formatPrice(value) {
            return new Intl.NumberFormat('vi-VN').format(value);
        },
    },
    mounted() {
        this.fetchData();
    }
}
</script>