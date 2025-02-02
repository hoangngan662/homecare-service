<template>
    <Spinner v-if="isHandle" />
    <Toast v-if="isSuccessVisible" :message="successMessage" :isVisible="isSuccessVisible" @close="hideSuccessToast" />
    <Toast v-if="isErrorVisible" :message="errorMessage" :isVisible="isErrorVisible" @close="hideErrorToast" />

    <div class="relative m-4 p-4 overflow-x-auto shadow-md sm:rounded-lg min-h-screen">
        <section class="bg-white dark:bg-gray-900 p-8 rounded-lg shadow-md flex flex-col lg:flex-row">
            <div class="flex-shrink-0 w-full lg:w-1/2">
                <img src="https://quymaiamhanhphuc.vn/upload/images/csskcongdong/cssk2.png" alt="Contact Image"
                    class="object-cover w-full h-full rounded-lg shadow-md" />
            </div>
            <div class="p-8 mx-auto max-w-screen-md w-full lg:w-1/2">
                <h2 class="mb-4 text-4xl tracking-tight font-extrabold text-center text-gray-900 dark:text-white">LIÊN
                    HỆ</h2>
                <p class="mb-4 lg:mb-8 font-light text-center text-gray-500 dark:text-gray-400 sm:text-xl">
                    Để lại thông tin để nhận được tư vấn, lựa chọn gói dịch vụ phù hợp nhất.
                </p>
                <form @submit.prevent="submitContact" class="space-y-8">
                    <div>
                        <label for="name" class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300">Họ và
                            tên
                            <span class="text-red-600 text-sm">*</span>
                        </label>
                        <input type="text" id="name" v-model="contact.patientName"
                            class="shadow-sm bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-primary-500 focus:border-primary-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500 dark:shadow-sm-light"
                            placeholder="Họ và tên" required>
                    </div>
                    <div>
                        <label for="phone" class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300">Số
                            điện thoại
                            <span class="text-red-600 text-sm">*</span>
                        </label>
                        <input type="tel" id="phone" v-model="contact.phoneNumber"
                            class="shadow-sm bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-primary-500 focus:border-primary-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500 dark:shadow-sm-light"
                            placeholder="0123123123" required pattern="^[0-9]{8,12}$">
                    </div>
                    <div>
                        <label for="service"
                            class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-300">Dịch vụ cần tư
                            vấn
                            <span class="text-red-600 text-sm">*</span>
                        </label>
                        <input type="text" id="service" v-model="contact.service"
                            class="block p-3 w-full text-sm text-gray-900 bg-gray-50 rounded-lg border border-gray-300 shadow-sm focus:ring-primary-500 focus:border-primary-500 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500 dark:shadow-sm-light"
                            placeholder="Dịch vụ cần tư vấn" required>
                    </div>
                    <div class="sm:col-span-2">
                        <label for="message" class="block mb-2 text-sm font-medium text-gray-900 dark:text-gray-400">Lời
                            nhắn</label>
                        <textarea id="message" rows="6" v-model="contact.message"
                            class="block p-2.5 w-full text-sm text-gray-900 bg-gray-50 rounded-lg shadow-sm border border-gray-300 focus:ring-primary-500 focus:border-primary-500 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500"
                            placeholder="Để lại lời nhắn..."></textarea>
                    </div>
                    <button type="submit"
                        class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 me-2 mb-2 dark:bg-blue-600 dark:hover:bg-blue-700 focus:outline-none dark:focus:ring-blue-800">
                        Gửi
                    </button>
                </form>
            </div>
        </section>
    </div>
</template>

<script>
import Spinner from '../Common/Spinner.vue';
import Toast from '../Common/Toast.vue';
export default {
    name: "Contact",
    components: {
        Spinner,
        Toast
    },
    data() {
        return {
            contact: {
                id: 0,
                patientName: '',
                phoneNumber: '',
                service: '',
                message: '',
                inquiryDate: '',
                status: 0,
                note: ''
            },
            isHandle: false,
            isSuccessVisible: false,
            isErrorVisible: false,
            successMessage: '',
            errorMessage: '',
        };
    },
    methods: {
        async submitContact() {
            this.isHandle = true;
            this.contact.inquiryDate = new Date().toISOString();
            console.log(this.contact);
            
            try {
                const response = await fetch('https://localhost:7072/api/contact', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(this.contact),
                });

                if (response.ok) {
                    this.showSuccessToast("Gửi thông tin thành công.");
                    this.resetForm();
                } else {
                    this.showErrorToast("Gửi thông tin thất bại, hãy kiểm tra lại.");
                }
            } catch (error) {
                this.showErrorToast("Gửi thông tin thất bại, hãy kiểm tra lại.");
            }
            finally {
                this.isHandle = false;
            }
        },
        resetForm() {
            this.contact = {
                id: '',
                patientName: '',
                phoneNumber: '',
                service: '',
                message: '',
                inquiryDate: '',
                status: 0,
                note: ''
            };
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
    }
}
</script>
