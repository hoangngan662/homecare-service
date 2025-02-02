<template>
    <Spinner v-if="isHandle" />
    <div class="relative p-4 overflow-x-auto shadow-md sm:rounded-lg">
        <h3 class="text-2xl font-extrabold dark:text-white">Thêm dịch vụ</h3>
        <br />
        <form @submit.prevent="addServiceType">
            <div class="mb-6">
                <label for="name" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Tên dịch
                    vụ
                    <span class="text-red-600 text-sm">*</span>
                </label>
                <input type="text" id="name" v-model="serviceType.name"
                    class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                    placeholder="Lấy mẫu xét nghiệm" required />
            </div>
            <div class="mb-6">
                <label for="description" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Mô
                    tả
                    <span class="text-red-600 text-sm">*</span>
                </label>
                <textarea id="description" v-model="serviceType.description"
                    class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                    placeholder="Nhập mô tả" required></textarea>
            </div>
            <div class="mb-6">
                <label for="image" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">
                    Hình ảnh
                    <span class="text-red-600 text-sm">*</span>
                </label>
                <input id="image" @change="handleFileUpload" accept="image/*"
                    class="block w-full text-sm text-gray-900 border border-gray-300 rounded-lg cursor-pointer bg-gray-50 dark:text-gray-400 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400"
                    type="file" required>
            </div>
            <button type="submit"
                class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">Thêm</button>
            <router-link to="/service-type"
                class="ml-3 font-medium text-blue-600 dark:text-blue-500 hover:underline">Quay
                lại</router-link>
        </form>
    </div>
</template>

<script>
import Spinner from '../Common/Spinner.vue';
export default {
    name: "AddServiceType",
    components: {
        Spinner
    },
    data() {
        return {
            serviceType: {
                name: '',
                description: '',
                image: null
            },
            isHandle: false
        };
    },
    methods: {
        handleFileUpload(event) {
            const file = event.target.files[0];
            if (file) {
                this.serviceType.image = file;
            }
        },
        async addServiceType() {
            try {
                this.isHandle = true;
                const formData = new FormData();
                formData.append('name', this.serviceType.name);
                formData.append('description', this.serviceType.description);
                if (this.serviceType.image) {
                    formData.append('image', this.serviceType.image); // Thêm tệp hình ảnh vào formData
                }

                const response = await fetch('https://localhost:7072/api/service/service-type', {
                    method: 'POST',
                    body: formData,
                });

                if (response.ok) {
                    alert('Thêm dịch vụ thành công!');
                    this.$router.push('/service-type');
                } else {
                    alert('Thêm dịch vụ thất bại.');
                    this.isHandle = false;
                }
            } catch (error) {
                console.error('Error:', error);
                alert('Có lỗi xảy ra. Hãy thử lại.');
            }
        },
    },
};
</script>