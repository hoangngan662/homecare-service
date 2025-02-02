<template>
    <Spinner v-if="isHandle" />
    <div class="relative p-4 overflow-x-auto shadow-md sm:rounded-lg">
        <h3 class="text-2xl font-extrabold dark:text-white">Đổi mật khẩu</h3>
        <br />
        <form @submit.prevent="changePassword">
            <div class="mb-6">
                <label for="oldPassword" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Mật
                    khẩu hiện tại</label>
                <input type="password" id="oldPassword" v-model="model.oldPassword"
                    class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                    placeholder="•••••••••" required />
            </div>
            <div class="mb-6">
                <label for="newPassword" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Mật khẩu
                    mới</label>
                <input type="password" id="newPassword" v-model="model.newPassword"
                    class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                    placeholder="•••••••••" required />
            </div>
            <div class="mb-6">
                <label for="confirmPassword" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Nhập
                    lại mật khẩu
                    mới</label>
                <input type="password" id="confirmPassword" v-model="confirmPassword"
                    class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                    placeholder="•••••••••" required />
            </div>
            <button type="submit"
                class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">Lưu</button>
            <router-link to="/"
                class="ml-3 font-medium text-blue-600 dark:text-blue-500 hover:underline">Quay
                lại</router-link>
        </form>
    </div>
</template>
<script>
import Spinner from '../Common/Spinner.vue';

export default {
    name: 'ChangePassword',
    components: {
        Spinner
    },
    data() {
        return {
            model: {
                id: '',
                oldPassword: '',
                newPassword: ''
            },
            confirmPassword: '',
            isHandle: false
        };
    },
    methods: {
        async changePassword() {
            this.isHandle = true;
            const id = localStorage.getItem('idStaff');
            if (!id) {
                alert('Vui lòng đăng nhập.');
                this.$router.push('/login');
                return;
            }

            this.model.id = id;

            if (this.model.newPassword !== this.confirmPassword) {
                this.isHandle = false;
                alert('Mật khẩu mới và nhập lại mật khẩu không khớp!');
                return;
            }

            try {
                console.log(this.model);
                const response = await fetch('https://localhost:7072/api/user/change-password', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(this.model)
                });

                if (response.ok) {
                    alert('Đổi mật khẩu thành công!');
                    this.$router.push('/');
                } else {
                    this.isHandle = false;
                    alert(`Đổi mật khẩu thất bại. Vui lòng kiểm tra lại!`);
                }
            } catch (error) {
                console.error('Error:', error);
                alert('Có lỗi xảy ra, vui lòng thử lại sau.');
            }
        },
    }
}
</script>