<template>
    <Spinner v-if="isHandle" />
    <div class="relative p-4 overflow-x-auto shadow-md sm:rounded-lg">
        <h3 class="text-2xl font-extrabold dark:text-white">Thông tin nhân viên</h3>
        <br />
        <form @submit.prevent="updateStaff">
            <div class="grid gap-6 mb-6 md:grid-cols-2">
                <div>
                    <label for="fullname" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Họ và
                        tên
                        <span class="text-red-600 text-sm">*</span>
                    </label>
                    <input type="text" id="fullname" v-model="staff.fullname" :disabled="!isEditing"
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
                        <input id="dob" type="date" v-model="staff.doB" :disabled="!isEditing"
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full ps-10 p-2.5  dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                            placeholder="Chọn ngày sinh" required>
                    </div>
                </div>
                <div>
                    <label for="email"
                        class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Email
                        <span class="text-red-600 text-sm">*</span>
                    </label>
                    <input type="email" id="email" v-model="staff.email" disabled
                        class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                        placeholder="nguyena@example.com" required />
                </div>
                <div>
                    <label for="phone" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Số điện
                        thoại
                        <span class="text-red-600 text-sm">*</span>
                    </label>
                    <input type="tel" id="phone" v-model="staff.phoneNumber" :disabled="!isEditing"
                        class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                        placeholder="123-45-678" pattern="^[0-9]{8,12}$" required />
                </div>
                <div>
                    <label for="address" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Địa
                        chỉ
                        <span class="text-red-600 text-sm">*</span>
                    </label>
                    <input type="text" id="address" v-model="staff.address" :disabled="!isEditing"
                        class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                        placeholder="123 Ninh Kieu" required />
                </div>
                <div>
                    <label for="specialization"
                        class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Chuyên môn
                        <span class="text-red-600 text-sm">*</span>
                    </label>
                    <input type="text" id="specialization" v-model="staff.specialization" :disabled="!isEditing"
                        class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                        placeholder="Vật lý trị liệu" required />
                </div>
                <div>
                    <label for="startdate" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Ngày vào
                        làm
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
                        <input id="startDate" type="date" v-model="staff.startDate" :disabled="!isEditing"
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full ps-10 p-2.5  dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                            placeholder="Chọn ngày vào làm" required>
                    </div>
                </div>
                <div>
                    <label for="role" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Chức
                        vụ
                        <span class="text-red-600 text-sm">*</span>
                    </label>
                    <div class="relative">
                        <select id="role" v-model="staff.roles[0]" :disabled="!isEditing"
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
                            <option value="Staff" selected>Nhân viên</option>
                            <option value="Admin">Quản lý</option>
                        </select>
                    </div>
                </div>
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
            <router-link to="/staff" class="font-medium text-blue-600 dark:text-blue-500 hover:underline">Quay
                lại</router-link>
        </form>
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
                        Xác nhận xóa người dùng?
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
</template>

<script>
import Spinner from '../Common/Spinner.vue';
export default {
    name: 'StaffDetail',
    components: {
        Spinner
    },
    data() {
        return {
            staff: {
                fullname: '',
                address: '',
                email: '',
                phoneNumber: '',
                password: '',
                doB: '',
                specialization: null,
                startDate: null,
                roles: [''],
            },
            isEditing: false,
            isHandle: false
        };
    },
    mounted() {
        this.fetchStaff();
    },
    methods: {
        async fetchStaff() {
            this.isHandle = true;
            const staffId = this.$route.params.id;
            try {
                const response = await fetch(`https://localhost:7072/api/user/${staffId}`);

                if (response.ok) {
                    const data = await response.json();
                    this.staff = {
                        ...data,
                        doB: this.formatDate(data.doB),
                        startDate: this.formatDate(data.startDate),
                    };
                    this.isHandle = false;
                } else {
                    alert('Có lỗi xảy ra. Hãy thử lại.');
                    this.$router.push('/staff');
                }
            } catch (error) {
                alert('Có lỗi xảy ra. Hãy thử lại.');
                this.$router.push('/staff');
            }
        },
        async updateStaff() {
            try {
                this.isHandle = true;
                const staffToUpdate = {
                    ...this.staff,
                    doB: this.formatDateForSubmission(this.staff.doB),
                    startDate: this.formatDateForSubmission(this.staff.startDate),
                    password: "password"
                };
                console.log(staffToUpdate);
                const response = await fetch(`https://localhost:7072/api/user/${this.staff.id}`, {
                    method: 'PUT',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(staffToUpdate),
                });

                if (response.ok) {
                    alert('Cập nhật thành công!');
                    this.$router.push('/staff');
                } else {
                    this.isHandle = false;
                    const error = await response.json();
                    alert(`Cập nhật thất bại`);
                    console.log(response);

                }
            } catch (error) {
                console.error('Error:', error);
                alert('Có lỗi xảy ra. Hãy thử lại.');

            }
        },
        formatDate(dateString) {
            if (!dateString) return '';
            const date = new Date(dateString);
            return date.toISOString().split('T')[0];
        },
        formatDateForSubmission(dateString) {
            return new Date(dateString).toISOString();
        },
        async confirmDelete() {
            this.isHandle = true;
            const staffId = this.$route.params.id;
            try {
                const response = await fetch(`https://localhost:7072/api/user/${staffId}`, {
                    method: 'DELETE',
                    headers: {
                        'Content-Type': 'application/json',
                    }
                });

                if (response.ok) {
                    alert('Xóa nhân viên thành công.');
                    this.$router.push('/staff');
                } else {
                    alert('Xóa nhân viên thất bại.');
                    this.isHandle = false;
                }
            } catch (error) {
                alert('Có lỗi xảy ra. Hãy thử lại.');
            }
        },
    },
};
</script>