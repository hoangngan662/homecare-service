<script setup>
import { ref } from 'vue';
import axios from 'axios';
import { useRouter } from 'vue-router';
import Spinner from '../Common/Spinner.vue';
import Toast from '../Common/Toast.vue';

const router = useRouter();
const isOpen = ref(false);
const userInfo = ref({
    fullname: '',
    address: '',
    email: '',
    phoneNumber: '',
    password: '',
    doB: '',
    specialization: null,
    startDate: null,
    roles: ['Patient'],
});
const role = ref(null);
const isHandle = ref(false);

const isSuccessVisible = ref(false);
const isErrorVisible = ref(false);
const successMessage = ref('');
const errorMessage = ref('');

const showSuccessToast = (message) => {
    successMessage.value = message;
    isSuccessVisible.value = true;
    setTimeout(hideSuccessToast, 3000);
};

const hideSuccessToast = () => {
    isSuccessVisible.value = false;
    localStorage.removeItem('logoutMessage');
    localStorage.removeItem('registerMessage');
};

const showErrorToast = (message) => {
    errorMessage.value = message;
    isErrorVisible.value = true;
    setTimeout(hideErrorToast, 3000);
};

const hideErrorToast = () => {
    isErrorVisible.value = false;
};

const callback = async (response) => {
    if (response && response.credential) {
        const token = response.credential;
        try {
            isHandle.value = true;
            const result = await axios.post('https://localhost:7072/api/auth/google-login', { tokenId: token });
            if (result.data.isNewUser) {
                isHandle.value = false;
                if (result.data.user) {
                    userInfo.value.fullname = result.data.user.fullname || '';
                    userInfo.value.email = result.data.user.email || '';
                    isOpen.value = true;
                } else {
                    showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
                }
            } else {
                const { token, username } = result.data;
                const decodedToken = decodeJwt(token);
                role.value = decodedToken.role;

                if (role.value === "Patient") {
                    localStorage.setItem('fullname', decodedToken.fullname);
                    localStorage.setItem('email', decodedToken.sub);
                    localStorage.setItem('role', decodedToken.role);
                    localStorage.setItem('id', decodedToken.jti);
                    localStorage.setItem('loginSuccessMessage', "Đăng nhập thành công.");
                    await router.push('/');
                    window.location.reload();
                } else {
                    showErrorToast("Đăng nhập thất bại.");
                }
            }
        } catch (error) {
            showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
        }
        finally{
            isHandle.value = false;
        }
    }
};

const decodeJwt = (token) => {
    const base64Url = token.split('.')[1];
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    const jsonPayload = decodeURIComponent(atob(base64).split('').map(c =>
        '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2)).join(''));

    return JSON.parse(jsonPayload);
};

// Hàm cập nhật thông tin người dùng
const updateUserInfo = async () => {    
    try {        
        isHandle.value = true;
        const response = await fetch('https://localhost:7072/api/auth/google-login-info', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(userInfo.value),
        });

        if (response.ok) {
            const responseData = await response.json();
            const { token, username } = responseData;
            const decodedToken = decodeJwt(token);
            role.value = decodedToken.role;

            if (role.value === "Patient") {
                localStorage.setItem('fullname', decodedToken.fullname);
                localStorage.setItem('email', decodedToken.sub);
                localStorage.setItem('role', decodedToken.role);
                localStorage.setItem('id', decodedToken.jti);
                localStorage.setItem('loginSuccessMessage', "Đăng nhập thành công.");
                await router.push('/');
                window.location.reload();
            } else {                
                showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
            }
        } else {
            showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
        }
    } catch (error) {
        showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
    }
    finally{
        isHandle.value = false;
    }
};

// Hàm đóng modal
const closeModal = () => {
    isOpen.value = false;
}
</script>

<template>
    <Spinner v-if="isHandle" />
    <GoogleLogin :callback="callback" />
    <Toast v-if="isSuccessVisible" :message="successMessage" :isVisible="isSuccessVisible" @close="hideSuccessToast" />
    <Toast v-if="isErrorVisible" :message="errorMessage" :isVisible="isErrorVisible" @close="hideErrorToast" />

    <div v-show="isOpen" tabindex="-1" aria-hidden="true"
        class="fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-50">
        <div class="relative w-full max-w-lg bg-white rounded-lg shadow dark:bg-gray-700">
            <div class="flex items-center justify-between p-4 md:p-5 border-b rounded-t dark:border-gray-600">
                <h3 class="text-lg font-semibold text-gray-900 dark:text-white">
                    <div class="flex items-center justify-center">
                        <img class="w-10 h-10" src="https://www.svgrepo.com/show/475656/google-color.svg" loading="lazy"
                            alt="google logo">
                        <span class="px-2 text-lg font-semibold text-gray-700 dark:text-white">Cập nhật thông tin</span>
                    </div>

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
            <form v-if="userInfo" class="p-4 md:p-5" @submit.prevent="updateUserInfo">
                <div class="grid gap-4 mb-6 md:grid-cols-2">
                    <div>
                        <label for="fullname" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Họ và
                            tên</label>
                        <input type="text" v-model="userInfo.fullname"
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                            placeholder="Nguyen Van A" required />
                    </div>
                    <div>
                        <label class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Email</label>
                        <input type="email" v-model="userInfo.email"
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                            placeholder="nguyena@example.com" disabled />
                    </div>
                    <div>
                        <label for="dob" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Ngày
                            sinh</label>
                        <div class="relative">
                            <div class="absolute inset-y-0 start-0 flex items-center ps-3 pointer-events-none">
                                <svg class="w-4 h-4 text-gray-500 dark:text-gray-400" aria-hidden="true"
                                    xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 20 20">
                                    <path
                                        d="M20 4a2 2 0 0 0-2-2h-2V1a1 1 0 0 0-2 0v1h-3V1a1 1 0 0 0-2 0v1H6V1a1 1 0 0 0-2 0v1H2a2 2 0 0 0-2 2v2h20V4ZM0 18a2 2 0 0 0 2 2h16a2 2 0 0 0 2-2V8H0v10Zm5-8h10a1 1 0 0 1 0 2H5a1 1 0 0 1 0-2Z" />
                                </svg>
                            </div>
                            <input datepicker-autohide type="date" v-model="userInfo.doB"
                                class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full ps-10 p-2.5  dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                                placeholder="Chọn ngày sinh" required>
                        </div>
                    </div>
                    <div>
                        <label for="phone" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Số điện
                            thoại</label>
                        <input type="tel" v-model="userInfo.phoneNumber"
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                            placeholder="0123456789" pattern="^[0-9]{8,12}$" required />
                    </div>
                    <div>
                        <label for="address" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Địa
                            chỉ</label>
                        <input type="text" v-model="userInfo.address"
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                            placeholder="123 Ninh Kieu" required />
                    </div>
                    <div>
                        <label class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">
                            Mật khẩu
                        </label>
                        <input type="password" v-model="userInfo.password"
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                            placeholder="•••••••••" required />
                    </div>
                </div>
                <button type="submit"
                    class="text-white inline-flex items-center bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">
                    Cập nhật
                </button>
            </form>
        </div>
    </div>
</template>
