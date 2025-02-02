
<script>
import Spinner from '../Common/Spinner.vue';
import GoogleLogin from './GoogleLogin.vue';
import Toast from '../Common/Toast.vue';

export default {
    name: "Register",
    components:{
        GoogleLogin,
        Spinner,
        Toast
    },
    data() {
        return {
            patient: {
                fullname: '',
                address: '',
                email: '',
                phoneNumber: '',
                password: '',
                doB: '',
                specialization: null,
                startDate: null,
                roles: ['Patient'],
            },
            isHandle: false,
            isSuccessVisible: false,
            isErrorVisible: false,
            successMessage: '',
            errorMessage: '',
        };
    },
    methods: {
        async register() {
            try {
                this.isHandle = true;
                const response = await fetch('https://localhost:7072/api/auth/register', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(this.patient),
                });                
                if (response.ok) {
                    localStorage.setItem('registerMessage', "Đăng ký thành công.");
                    this.$router.push('/login');
                } else {
                    const data = await response.json();
                    this.showErrorToast(data.message || "Đăng ký thất bại.");
                }
            } catch (error) {
                this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
            }
            finally{
                this.isHandle = false;
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
    },
}
</script>

<template>
    <Spinner v-if="isHandle" />
    <Toast v-if="isSuccessVisible" :message="successMessage" :isVisible="isSuccessVisible" @close="hideSuccessToast" />
    <Toast v-if="isErrorVisible" :message="errorMessage" :isVisible="isErrorVisible" @close="hideErrorToast" />
    <div class="flex items-center justify-center h-screen px-6 bg-gray-200 dark:bg-gray-600">
        <div class="w-full max-w-2xl p-6 bg-white rounded-md shadow-md dark:bg-gray-800">
            <a href="/" class="flex items-center justify-center">
                <img src="/home.png" class="w-10 h-10" />
                <span class="px-2 text-2xl font-semibold text-gray-700 dark:text-white">Đăng ký</span>
            </a>

            <form class="mt-4" @submit.prevent="register">
                <div class="grid gap-4 mb-6 md:grid-cols-2">
                    <div>
                        <label for="fullname" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Họ và
                            tên
                            <span class="text-red-600 text-sm">*</span>
                        </label>
                        <input type="text" id="fullname" v-model="patient.fullname"
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                            placeholder="Nguyen Van A" required />
                    </div>
                    <div>
                        <label for="dob" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Ngày
                            sinh
                            <span class="text-red-600 text-sm">*</span>
                        </label>
                        <div class="relative">
                            <div class="absolute inset-y-0 start-0 flex items-center ps-3 pointer-events-none">
                                <svg class="w-4 h-4 text-gray-500 dark:text-gray-400" aria-hidden="true"
                                    xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 20 20">
                                    <path
                                        d="M20 4a2 2 0 0 0-2-2h-2V1a1 1 0 0 0-2 0v1h-3V1a1 1 0 0 0-2 0v1H6V1a1 1 0 0 0-2 0v1H2a2 2 0 0 0-2 2v2h20V4ZM0 18a2 2 0 0 0 2 2h16a2 2 0 0 0 2-2V8H0v10Zm5-8h10a1 1 0 0 1 0 2H5a1 1 0 0 1 0-2Z" />
                                </svg>
                            </div>
                            <input id="dob" datepicker-autohide type="date" v-model="patient.doB"
                                class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full ps-10 p-2.5  dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                                placeholder="Chọn ngày sinh" required>
                        </div>
                    </div>
                    <div>
                        <label for="email"
                            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Email
                            <span class="text-red-600 text-sm">*</span>
                        </label>
                        <input type="email" id="email" v-model="patient.email"
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                            placeholder="nguyena@example.com" required />
                    </div>
                    <div>
                        <label for="phone" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Số điện
                            thoại
                            <span class="text-red-600 text-sm">*</span>
                        </label>
                        <input type="tel" id="phone" v-model="patient.phoneNumber"
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                            placeholder="0123456789" pattern="^[0-9]{8,12}$" required />
                    </div>
                    <div>
                        <label for="address" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Địa
                            chỉ
                            <span class="text-red-600 text-sm">*</span>
                        </label>
                        <input type="text" id="address" v-model="patient.address"
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                            placeholder="123 Ninh Kieu" required />
                    </div>

                    <div>
                        <label for="password" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Mật
                            khẩu
                            <span class="text-red-600 text-sm">*</span>
                        </label>
                        <input type="password" id="password" v-model="patient.password"
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                            placeholder="•••••••••" required />
                    </div>
                </div>

                <div class="mt-6">
                    <button type="submit"
                        class="w-full text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 me-2 mb-2 dark:bg-blue-600 dark:hover:bg-blue-700 focus:outline-none dark:focus:ring-blue-800">
                        ĐĂNG KÝ
                    </button>
                </div>
            </form>

            <p class="mb-3 text-gray-500 dark:text-gray-400 font-italic text-sm">Đã có tài khoản?
                <router-link to="/login" class="text-sm text-blue-500 hover:underline dark:text-blue-400">Đăng nhập</router-link>
            </p>
            <p class="divider mb-3 text-gray-500 dark:text-gray-400 font-italic text-sm text-center">Hoặc</p>
            <div class="flex justify-center items-center">
                <GoogleLogin/>
            </div>
        </div>
    </div>
</template>


<style>
.divider {
    display: flex;
    align-items: center;
    text-align: center;
}

.divider::before,
.divider::after {
    content: '';
    flex: 1;
    border-bottom: 1px solid #d1d5db;
    /* light gray */
}

.divider::before {
    margin-right: .5em;
}

.divider::after {
    margin-left: .5em;
}

.dark .divider::before,
.dark .divider::after {
    border-color: #4b5563;
    /* dark gray for dark mode */
}
</style>