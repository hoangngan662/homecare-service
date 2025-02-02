<template>
    <div class="relative p-4 overflow-x-auto shadow-md sm:rounded-lg">
        <h3 class="text-2xl font-extrabold dark:text-white">Liên hệ tư vấn</h3>
        <p class="my-4 text-sm text-gray-500">Danh sách liên hệ tư vấn</p>

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
                        Số điện thoại
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Dịch vụ cần tư vấn
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
                <tr v-for="(contact, index) in contacts" :key="contact.id"
                    class="bg-white border-b dark:bg-gray-800 dark:border-gray-700 hover:bg-gray-50 dark:hover:bg-gray-600">
                    <td class="px-6 py-4">
                        {{ index + 1 }}
                    </td>
                    <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                        {{ contact.patientName }}
                    </th>
                    <td class="px-6 py-4">
                        {{ contact.phoneNumber }}
                    </td>
                    <td class="px-6 py-4">
                        {{ contact.service }}
                    </td>
                    <td class="px-6 py-4">
                        <span v-if="contact?.status === 1">Xong</span>
                        <span v-else-if="contact?.status === 0">Chưa xử lý</span>
                        <span v-else></span>
                    </td>
                    <td class="px-6 py-4">
                        <button @click="openModal(contact)"
                            class="font-medium text-blue-600 dark:text-blue-500 hover:underline">Chi tiết</button>
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
    <div v-show="isModalDetail" tabindex="-1" aria-hidden="true" @click.self="closeModal"
        class="fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-50">
        <div class="relative p-4 w-full max-w-md max-h-full bg-white rounded-lg shadow dark:bg-gray-700">
            <div class="flex items-center justify-between p-4 md:p-5 border-b rounded-t dark:border-gray-600">
                <h3 class="text-lg font-semibold text-gray-900 dark:text-white">
                    Chi tiết liên hệ tư vấn
                </h3>
                <button type="button" @click="closeModal"
                    class="text-gray-400 bg-transparent hover:bg-gray-200 hover:text-gray-900 rounded-lg text-sm w-8 h-8 inline-flex justify-center items-center dark:hover:bg-gray-600 dark:hover:text-white">
                    <svg class="w-3 h-3" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none"
                        viewBox="0 0 14 14">
                        <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                            d="m1 1 6 6m0 0 6 6M7 7l6-6M7 7l-6 6" />
                    </svg>
                    <span class="sr-only">Close modal</span>
                </button>
            </div>

            <!-- Thông tin chi tiết -->
            <div class="p-2 space-y-4">
                <div class="flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Khách hàng:</label>
                    <div class="flex-1 text-left">{{ contactSelected?.patientName }}</div>
                </div>
                <div class="flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Số điện thoại:</label>
                    <div class="flex-1 text-left">{{ contactSelected?.phoneNumber }}</div>
                </div>
                <div class="flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Dịch vụ:</label>
                    <div class="flex-1 text-left">{{ contactSelected?.service }}</div>
                </div>
                <div class="flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Lời nhắn:</label>
                    <div class="flex-1 text-left">{{ contactSelected?.message }}</div>
                </div>
                <div class="flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Ngày gửi:</label>
                    <div class="flex-1 text-left">{{ formatDate(contactSelected?.inquiryDate) }}</div>
                </div>
                <div class="flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Trạng thái:</label>
                    <div class="flex-1 text-left">
                        <span v-if="contactSelected?.status === 1">Xong</span>
                        <span v-else-if="contactSelected?.status === 0">Chưa xử lý</span>
                        <span v-else></span>
                    </div>
                </div>
                <div class="flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Ghi chú:</label>
                    <div class="flex-1 text-left">

                        <input v-if="contactSelected?.status === 0" type="text" v-model="contactSelected.note"
                            class="border rounded p-1 w-full bg-gray-50 border-gray-300 text-gray-900 text-sm focus:ring-blue-500 focus:border-blue-500 block dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" />
                        <span v-else>{{ contactSelected?.note || 'Không có ghi chú' }}</span>
                    </div>
                </div>
            </div>
            <button type="button" @click="complete" v-if="contactSelected?.status === 0"
                class="p-2 text-white inline-flex items-center bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">
                Hoàn thành
            </button>
        </div>
    </div>
</template>
<script>
import axios from 'axios';
export default{
    name: "Contact",
    data() {
        return {
            contacts: [],
            pageNumber: 1,
            pageSize: 5,
            totalCount: 0,
            isModalDetail: false,
            contactSelected: null,
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
        async fetchContacts() {
            try {
                const response = await axios.get('https://localhost:7072/api/contact', {
                    params: {
                        pageNumber: this.pageNumber,
                        pageSize: this.pageSize,
                    }
                });

                this.contacts = response.data.items;
                this.totalCount = response.data.totalCount;
            } catch (error) {
                console.error("There was an error fetching the Service Types:", error);
            }
        },
        async complete(){
            console.log(this.contactSelected);
            this.contactSelected.status = 1;
            try {
                const response = await fetch(`https://localhost:7072/api/contact/${this.contactSelected.id}`, {
                    method: 'PUT',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(this.contactSelected),
                });

                if (response.ok) {
                    alert("Xác nhận thành công.");
                    location.reload();
                } else {
                    alert("Đã có lỗi xảy ra. Hãy thử lại.");
                }
            } catch (error) {
                alert("Đã có lỗi xảy ra. Hãy thử lại.");
            }
        },
        prevPage() {
            if (this.pageNumber > 1) {
                this.pageNumber--;
                this.fetchContacts();
            }
        },
        nextPage() {
            if (this.pageNumber < this.totalPages) {
                this.pageNumber++;
                this.fetchContacts();
            }
        },
        goToPage(page) {
            if (page !== '...') {
                this.pageNumber = page;
                this.fetchContacts();
            }
        },
        openModal(contact) {
            this.contactSelected = contact;
            console.log(this.contactSelected);
            
            this.isModalDetail = true;
        },
        closeModal() {
            this.isModalDetail = false;
            this.contactSelected = null;
        },
        formatDate(dateString) {
            const date = new Date(dateString);
            return date.toLocaleDateString('vi-VN', { day: '2-digit', month: '2-digit', year: 'numeric' });
        },
    },
    mounted() {
        this.fetchContacts();
    }
}
</script>