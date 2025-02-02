<template>
    <Spinner v-if="isHandle" />
    <Toast v-if="isSuccessVisible" :message="successMessage" :isVisible="isSuccessVisible" @close="hideSuccessToast" />
    <Toast v-if="isErrorVisible" :message="errorMessage" :isVisible="isErrorVisible" @close="hideErrorToast" />

    <div class="flex items-center justify-center h-screen px-6 bg-gray-200 dark:bg-gray-600">
        <div class="w-full max-w-sm p-6 bg-white rounded-md shadow-md dark:bg-gray-800">
            <a href="/" class="flex items-center justify-center">
                <img src="/home.png" class="w-10 h-10" />
                <span class="px-2 text-2xl font-semibold text-gray-700 dark:text-white">Đăng nhập</span>
            </a>

            <form class="mt-4" @submit.prevent="login">
                <div class="mt-4">
                    <label for="email"
                        class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Email
                        <span class="text-red-600 text-sm">*</span>
                    </label>
                    <input type="email" id="email" v-model="model.email"
                        class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                        placeholder="nguyena@example.com" required />
                </div>

                <div class="mt-4">
                    <label for="password" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Mật
                        khẩu
                        <span class="text-red-600 text-sm">*</span>
                    </label>
                    <input type="password" id="password" v-model="model.password"
                        class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                        placeholder="•••••••••" required />
                </div>

                <div class="mt-6">
                    <button type="submit"
                        class="w-full text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 me-2 mb-2 dark:bg-blue-600 dark:hover:bg-blue-700 focus:outline-none dark:focus:ring-blue-800">ĐĂNG
                        NHẬP</button>
                </div>
            </form>

            <p class="mb-3 text-gray-500 dark:text-gray-400 font-italic text-sm">Chưa có tài khoản?
                <router-link to="/register" class="text-sm text-blue-500 hover:underline dark:text-blue-400">Đăng
                    ký</router-link>
            </p>
            <p class="divider mb-3 text-gray-500 dark:text-gray-400 font-italic text-sm text-center">Hoặc</p>
            <div class="flex justify-center items-center">
                <GoogleLogin />
            </div>
        </div>
    </div>
</template>

<script>
import Spinner from '../Common/Spinner.vue';
import Toast from '../Common/Toast.vue';
import GoogleLogin from './GoogleLogin.vue';

export default {
    name: "Login",
    components: {
        GoogleLogin,
        Spinner,
        Toast
    },
    data() {
        return {
            model: {
                email: '',
                password: ''
            },
            isHandle: false,
            isSuccessVisible: false,
            isErrorVisible: false,
            successMessage: '',
            errorMessage: '',
        };
    },
    methods: {
        async login() {
            try {
                this.isHandle = true;
                const response = await fetch('https://localhost:7072/api/auth/login', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(this.model),
                });

                if (response.ok) {
                    const data = await response.json();
                    const { token } = data;
                    const decodedToken = this.decodeJwt(token);

                    // Check user role
                    if (decodedToken.role === "Patient") {
                        this.handleLoginSuccess(decodedToken);
                    } else {
                        this.showErrorToast("Đăng nhập thất bại. Vai trò không hợp lệ.");
                    }

                } else {
                    const data = await response.json();
                    this.showErrorToast(data.message || "Đăng nhập thất bại.");
                }
            } catch (error) {
                this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
            } finally {
                this.isHandle = false;
            }
        },
        handleLoginSuccess(decodedToken) {
            localStorage.setItem('fullname', decodedToken.fullname);
            localStorage.setItem('email', decodedToken.sub);
            localStorage.setItem('role', decodedToken.role);
            localStorage.setItem('id', decodedToken.jti);
            localStorage.setItem('loginSuccessMessage', "Đăng nhập thành công.");
            this.$router.push('/').then(() => {
                window.location.reload();
            });
        },
        showSuccessToast(message) {
            this.successMessage = message;
            this.isSuccessVisible = true;
            setTimeout(this.hideSuccessToast, 3000);
        },
        hideSuccessToast() {
            this.isSuccessVisible = false;
            localStorage.removeItem('logoutMessage');
            localStorage.removeItem('registerMessage');
        },
        showErrorToast(message) {
            this.errorMessage = message;
            this.isErrorVisible = true;
            setTimeout(this.hideErrorToast, 3000);
        },
        hideErrorToast() {
            this.isErrorVisible = false;
        },
        decodeJwt(token) {
            const base64Url = token.split('.')[1];
            const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
            const jsonPayload = decodeURIComponent(atob(base64).split('').map(c => '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2)).join(''));
            return JSON.parse(jsonPayload);
        },
    },
    mounted() {
        const messageLogout = localStorage.getItem('logoutMessage');
        const messageReg = localStorage.getItem('registerMessage');
        
        if (messageLogout) {
            this.successMessage = messageLogout;
            this.isSuccessVisible = true;

            // Set a timeout to hide the toast after 3 seconds
            setTimeout(() => {
                this.hideSuccessToast();
            }, 2000);            
        }

        if (messageReg) {
            this.successMessage = messageReg;
            this.isSuccessVisible = true;

            // Set a timeout to hide the toast after 3 seconds
            setTimeout(() => {
                this.hideSuccessToast();
            }, 2000);            
        }

        const email = localStorage.getItem('email');
        if (email) {
            this.$router.push('/').then(() => {
                window.location.reload();
            });
        }
    }
}
</script>

<style scoped>
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
}
</style>
