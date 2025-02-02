<template>
    <Spinner v-if="isHandle" />
    <div class="relative p-4 overflow-x-auto shadow-md sm:rounded-lg">
        <div class="mt-4 grid grid-cols-2 gap-5">
            <div>
                <h3 class="text-2xl font-extrabold dark:text-white">Chi tiết dịch vụ</h3>
                <br />
                <form @submit.prevent="updateServiceType">
                    <div class="mb-6">
                        <label for="name" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Tên dịch
                            vụ
                            <span class="text-red-600 text-sm">*</span>
                        </label>
                        <input type="text" id="name" v-model="service.name" :disabled="!isEditing"
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                            placeholder="Lấy mẫu xét nghiệm" required />
                    </div>
                    <div class="mb-6">
                        <label for="description" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Mô
                            tả
                            <span class="text-red-600 text-sm">*</span>
                        </label>
                        <textarea id="description" v-model="service.description" :disabled="!isEditing"
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                            placeholder="Nhập mô tả" required></textarea>
                    </div>
                    <div v-if="isEditing" class="mb-6">
                        <label for="image" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Hình
                            ảnh
                            <span class="text-red-600 text-sm">*</span>
                        </label>
                        <input id="image" @change="handleFileUpload" accept="image/*"
                            class="block w-full text-sm text-gray-900 border border-gray-300 rounded-lg cursor-pointer bg-gray-50 dark:text-gray-400 focus:outline-none dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400"
                            type="file">
                    </div>
                    <button v-if="isEditing" type="submit"
                        class="mr-3 text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">
                        Cập nhật
                    </button>
                    <button v-else type="button" @click="isEditing = true"
                        class="mr-3 text-gray-900 bg-white border border-gray-300 focus:outline-none hover:bg-gray-100 focus:ring-4 focus:ring-gray-100 font-medium rounded-lg text-sm px-5 py-2.5 me-2 mb-2 dark:bg-gray-800 dark:text-white dark:border-gray-600 dark:hover:bg-gray-700 dark:hover:border-gray-600 dark:focus:ring-gray-700">
                        Chỉnh sửa
                    </button>
                    <button type="button" data-modal-target="default-model" data-modal-toggle="default-model"
                        class="mr-3 focus:outline-none text-white bg-red-600 hover:bg-red-800 focus:ring-4 focus:ring-red-300 font-medium rounded-lg text-sm px-5 py-2.5 me-2 mb-2 dark:bg-red-600 dark:hover:bg-red-700 dark:focus:ring-red-900">Xóa</button>
                    <router-link to="/service-type"
                        class="font-medium text-blue-600 dark:text-blue-500 hover:underline">Quay
                        lại</router-link>
                </form>
            </div>
            <div>
                <img class="h-auto max-w-full rounded-lg mb-5" :src="curImage" alt="">
            </div>
        </div>

        <h3 class="mt-4 text-xl font-extrabold dark:text-white">Các gói dịch vụ</h3>
        <br />
        <button type="button" @click="openCrudModal"
            class="flex items-center w-fit text-gray-900 bg-white border border-gray-300 focus:outline-none hover:bg-gray-100 focus:ring-4 focus:ring-gray-100 font-medium rounded-full text-sm px-5 py-2.5 me-2 mb-2 dark:bg-gray-800 dark:text-white dark:border-gray-600 dark:hover:bg-gray-700 dark:hover:border-gray-600 dark:focus:ring-gray-700">
            <svg class="w-6 h-6 text-gray-800 dark:text-white me-2" aria-hidden="true"
                xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none" viewBox="0 0 24 24">
                <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                    d="M5 12h14m-7 7V5" />
            </svg>
            Thêm
        </button>
        <table class="w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400">
            <thead class="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
                <tr>
                    <th scope="col" class="px-6 py-3">
                        STT
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Tên gói
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Giá (VND)
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Số buổi
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Số tháng
                    </th>
                    <th scope="col" class="px-6 py-3">
                        Xử lí
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(pack, index) in servicePackages" :key="pack.id"
                    class="bg-white border-b dark:bg-gray-800 dark:border-gray-700 hover:bg-gray-50 dark:hover:bg-gray-600">
                    <td class="px-6 py-4">
                        {{ index + 1 }}
                    </td>
                    <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                        {{ pack.name }}
                    </th>
                    <td class="px-6 py-4">
                        {{ formatPrice(pack.price) }}
                    </td>
                    <td class="px-6 py-4">
                        {{ pack.numberOfSessions }}
                    </td>
                    <td class="px-6 py-4">
                        {{ pack.durationInMonths }}
                    </td>
                    <td class="px-6 py-4">
                        <button @click="openEditModal(pack)"
                            class="font-medium text-blue-600 dark:text-blue-500 hover:underline">Sửa</button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div id="default-model" tabindex="-1" aria-hidden="true"
        class="hidden fixed inset-0 z-50 justify-center items-center w-full h-full bg-black bg-opacity-50">
        <div class="relative p-4 w-full max-w-xl max-h-full">
            <div class="relative bg-white rounded-lg shadow dark:bg-gray-700">
                <div class="flex items-center justify-between p-4 md:p-5 border-b rounded-t dark:border-gray-600">
                    <h3 class="text-xl font-semibold text-gray-900 dark:text-white">
                        Xác nhận xóa
                    </h3>
                </div>
                <div class="p-4 md:p-5 space-y-4">
                    <p class="text-base leading-relaxed text-gray-500 dark:text-gray-400">
                        Xác nhận ngừng dịch vụ này?
                    </p>
                </div>
                <div
                    class="flex items-center justify-end p-4 md:p-5 border-t border-gray-200 rounded-b dark:border-gray-600">
                    <button data-modal-hide="default-model" type="button" @click="confirmDelete"
                        class="text-white bg-red-600 hover:bg-red-800 focus:ring-4 focus:outline-none focus:ring-red-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-red-600 dark:hover:bg-red-700 dark:focus:ring-red-900">
                        Xác nhận
                    </button>
                    <button data-modal-hide="default-model" type="button"
                        class="py-2.5 px-5 ms-3 text-sm font-medium text-gray-900 focus:outline-none bg-white rounded-lg border border-gray-200 hover:bg-gray-100 hover:text-blue-700 focus:z-10 focus:ring-4 focus:ring-gray-100 dark:focus:ring-gray-700 dark:bg-gray-800 dark:text-gray-400 dark:border-gray-600 dark:hover:text-white dark:hover:bg-gray-700">
                        Hủy
                    </button>
                </div>
            </div>
        </div>
    </div>

    <div v-show="isModalCreateVisible" tabindex="-1" aria-hidden="true" @click.self="closeCrudModal"
        class="fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-50">
        <div class="relative p-4 w-full max-w-md max-h-full bg-white rounded-lg shadow dark:bg-gray-700">
            <div class="flex items-center justify-between p-4 md:p-5 border-b rounded-t dark:border-gray-600">
                <h3 class="text-lg font-semibold text-gray-900 dark:text-white">
                    Thêm gói dịch vụ
                </h3>
                <button type="button" @click="closeCrudModal"
                    class="text-gray-400 bg-transparent hover:bg-gray-200 hover:text-gray-900 rounded-lg text-sm w-8 h-8 inline-flex justify-center items-center dark:hover:bg-gray-600 dark:hover:text-white">
                    <svg class="w-3 h-3" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none"
                        viewBox="0 0 14 14">
                        <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                            d="m1 1 6 6m0 0 6 6M7 7l6-6M7 7l-6 6" />
                    </svg>
                    <span class="sr-only">Close modal</span>
                </button>
            </div>
            <form class="p-4 md:p-5" @submit.prevent="addPackage">
                <div class="grid gap-4 mb-4 grid-cols-2">
                    <div class="col-span-2">
                        <label for="name" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Tên
                            gói
                            <span class="text-red-600 text-sm">*</span>
                        </label>
                        <input type="text" name="name" id="name" v-model="servicePackage.name"
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-600 dark:border-gray-500 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500"
                            placeholder="Vật lý trị liệu 1 tháng" required="">
                    </div>
                    <div class="col-span-2">
                        <label for="price"
                            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Giá
                            <span class="text-red-600 text-sm">*</span>
                        </label>
                        <input type="text" name="price" id="price" v-model="servicePackage.price"
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-600 dark:border-gray-500 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500"
                            placeholder="5000000" required="">
                    </div>
                    <div class="col-span-2 sm:col-span-1">
                        <label for="numberOfSessions"
                            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Số
                            buổi
                            <span class="text-red-600 text-sm">*</span>
                        </label>
                        <input type="number" name="numberOfSessions" id="numberOfSessions"
                            v-model="servicePackage.numberOfSessions"
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-600 dark:border-gray-500 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500"
                            placeholder="10" required="" min="0">
                    </div>
                    <div class="col-span-2 sm:col-span-1">
                        <label for="durationInMonths"
                            class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Số tháng
                            <span class="text-red-600 text-sm">*</span>
                        </label>
                        <input type="number" name="durationInMonths" id="durationInMonths"
                            v-model="servicePackage.durationInMonths"
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-600 dark:border-gray-500 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500"
                            placeholder="1" required="" min="0">
                    </div>
                </div>
                <button type="submit"
                    class="text-white inline-flex items-center bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">
                    <svg class="me-1 -ms-1 w-5 h-5" fill="currentColor" viewBox="0 0 20 20"
                        xmlns="http://www.w3.org/2000/svg">
                        <path fill-rule="evenodd"
                            d="M10 5a1 1 0 011 1v3h3a1 1 0 110 2h-3v3a1 1 0 11-2 0v-3H6a1 1 0 110-2h3V6a1 1 0 011-1z"
                            clip-rule="evenodd"></path>
                    </svg>
                    Thêm
                </button>
            </form>
        </div>
    </div>


    <div v-show="isModalVisible" tabindex="-1" aria-hidden="true" @click.self="closeEditModal"
        class="fixed inset-0 z-50 flex justify-center items-center w-full h-full bg-black bg-opacity-50">
        <div class="relative p-4 w-full max-w-md max-h-full bg-white rounded-lg shadow dark:bg-gray-700">
            <!-- Modal header -->
            <div class="flex items-center justify-between p-4 border-b rounded-t dark:border-gray-600">
                <h3 class="text-lg font-semibold text-gray-900 dark:text-white">Chỉnh sửa gói dịch vụ</h3>
                <button @click="closeEditModal"
                    class="text-gray-400 hover:bg-gray-200 dark:hover:bg-gray-600 p-2 rounded-lg">
                    <svg class="w-3 h-3" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 14 14">
                        <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                            d="M1 1l6 6m0 0l6 6M7 7L1 13M7 7L13 1" />
                    </svg>
                </button>
            </div>
            <!-- Modal body -->
            <div class="p-4">
                <div class="col-span-2 mb-4">
                    <label for="name" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Tên
                        gói
                        <span class="text-red-600 text-sm">*</span>
                    </label>
                    <input type="text" name="name" id="name" v-model="selectedPackage.name"
                        class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-600 dark:border-gray-500 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500"
                        placeholder="Vật lý trị liệu 1 tháng" required="">
                </div>
                <div class="col-span-2 mb-4">
                    <label for="price" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Giá
                        <span class="text-red-600 text-sm">*</span>
                    </label>
                    <input type="text" name="price" id="price" v-model="selectedPackage.price"
                        class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-600 dark:border-gray-500 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500"
                        placeholder="5000000" required="">
                </div>
                <div class="col-span-2 sm:col-span-1 mb-4">
                    <label for="numberOfSessions"
                        class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Số buổi
                        <span class="text-red-600 text-sm">*</span>
                    </label>
                    <input type="number" name="numberOfSessions" id="numberOfSessions"
                        v-model="selectedPackage.numberOfSessions"
                        class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-600 dark:border-gray-500 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500"
                        placeholder="10" required="" min="0">
                </div>
                <div class="col-span-2 sm:col-span-1 mb-4">
                    <label for="durationInMonths"
                        class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Số tháng
                        <span class="text-red-600 text-sm">*</span>
                    </label>
                    <input type="number" name="durationInMonths" id="durationInMonths"
                        v-model="selectedPackage.durationInMonths"
                        class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-gray-600 dark:border-gray-500 dark:placeholder-gray-400 dark:text-white dark:focus:ring-primary-500 dark:focus:border-primary-500"
                        placeholder="1" required="" min="0">
                </div>
            </div>
            <!-- Modal footer -->
            <div class="flex justify-end p-4">
                <button @click="updatePackage" class="bg-blue-600 text-white px-4 py-2 rounded-lg mr-2">Lưu</button>
                <button @click="deletePackage" class="bg-red-600 text-white px-4 py-2 rounded-lg">Xóa</button>
            </div>
        </div>
    </div>



</template>
<script>
import Spinner from '../Common/Spinner.vue';
export default {
    name: 'ServiceTypeDetail',
    components: {
        Spinner
    },
    data() {
        return {
            service: {
                name: '',
                description: '',
                image: null
            },
            curImage: null,
            isEditing: false,
            servicePackages: [],
            serviceId: '',
            servicePackage: {
                name: '',
                price: '',
                numberOfSessions: '',
                durationInMonths: '',
                serviceTypeId: ''
            },
            isModalVisible: false,
            isModalCreateVisible: false,
            selectedPackage: {},
            isHandle: false
        };
    },
    mounted() {
        this.fetchServiceType();
    },
    methods: {        
        async fetchServiceType() {
            this.isHandle = true;
            this.serviceId = this.$route.params.id;
            try {                
                const response = await fetch(`https://localhost:7072/api/service/service-types/${this.serviceId}`);
                if (response.ok) {
                    const data = await response.json();
                    const backendUrl = 'https://localhost:7072';
                    this.service = {
                        name: data.name,
                        description: data.description,                        
                    };
                    this.curImage = `${backendUrl}${data.image}`
                    this.servicePackages = data.servicePackages;
                    this.servicePackage.serviceTypeId = this.serviceId;
                    this.isHandle = false;
                } else {
                    alert('Có lỗi xảy ra. Hãy thử lại.');
                    this.$router.push('/service-type');
                }
            } catch (error) {
                alert('Có lỗi xảy ra. Hãy thử lại.');
                this.$router.push('/service-type');
            }
        },
        handleFileUpload(event) {
            const file = event.target.files[0];
            if (file) {
                this.service.image = file;
            }
        },
        async updateServiceType() {
            this.isHandle = true;
            try {
                const formData = new FormData();
                formData.append('name', this.service.name);
                formData.append('description', this.service.description);
                if (this.service.image) {
                    formData.append('image', this.service.image);
                }
                const response = await fetch(`https://localhost:7072/api/service/service-type/${this.serviceId}`, {
                    method: 'PUT',
                    body: formData,
                });

                if (response.ok) {
                    alert('Cập nhật dịch vụ thành công!');
                    this.$router.push('/service-type');
                } else {
                    const error = await response.json();
                    alert(`Cập nhật dịch vụ thất bại.`);
                    this.isHandle = false;
                }
            } catch (error) {
                console.error('Error:', error);
                alert('Có lỗi xảy ra. Hãy thử lại.');
            }
        },
        async confirmDelete() {
            try {
                this.isHandle = true;
                const response = await fetch(`https://localhost:7072/api/service/service-type/${this.serviceId}`, {
                    method: 'DELETE',
                    headers: {
                        'Content-Type': 'application/json',
                    }
                });

                if (response.ok) {
                    alert('Xóa dịch vụ thành công.');
                    this.$router.push('/service-type');
                } else {
                    alert('Có lỗi xảy ra. Hãy thử lại.');
                    this.isHandle = false;
                }
            } catch (error) {
                alert('Có lỗi xảy ra. Hãy thử lại.');
            }
        },
        async addPackage() {
            try {
                this.isHandle = true;
                const response = await fetch('https://localhost:7072/api/service/service-package', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(this.servicePackage),
                });

                if (response.ok) {
                    alert('Thêm gói dịch vụ thành công!');
                    location.reload();
                } else {
                    alert('Có lỗi xảy ra. Hãy thử lại.');
                }
            } catch (error) {
                console.error('Error:', error);
                alert('Có lỗi xảy ra. Hãy thử lại.');
            }
        },
        formatPrice(value) {
            return new Intl.NumberFormat('vi-VN').format(value);
        },
        openCrudModal() {
            this.isModalCreateVisible = true;
        },
        closeCrudModal() {
            this.isModalCreateVisible = false;
        },
        openEditModal(pack) {
            this.selectedPackage = { ...pack };
            this.isModalVisible = true;
        },
        closeEditModal() {
            this.isModalVisible = false;
        },
        async updatePackage() {
            try {
                this.isHandle = true;
                const response = await fetch(`https://localhost:7072/api/service/service-package/${this.selectedPackage.id}`, {
                    method: 'PUT',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(this.selectedPackage),
                });

                if (response.ok) {
                    alert('Cập nhật gói dịch vụ thành công!');
                    location.reload();
                } else {
                    alert('Có lỗi xảy ra. Hãy thử lại.');
                    this.isHandle = false;
                }
            } catch (error) {
                console.error('Error:', error);
                alert('Có lỗi xảy ra. Hãy thử lại.');
            }
            this.isModalVisible = false;
        },
        async deletePackage() {
            try {
                this.isHandle = true;
                const response = await fetch(`https://localhost:7072/api/service/service-package/${this.selectedPackage.id}`, {
                    method: 'DELETE',
                    headers: {
                        'Content-Type': 'application/json',
                    }
                });

                if (response.ok) {
                    alert('Xóa gói dịch vụ thành công!');
                    location.reload();
                } else {
                    alert('Có lỗi xảy ra. Hãy thử lại.');
                    this.isHandle = false;
                }
            } catch (error) {
                console.error('Error:', error);
                alert('Có lỗi xảy ra. Hãy thử lại.');
            }
            this.isModalVisible = false;
        }
    },
}
</script>