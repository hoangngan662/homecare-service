<template>
    <Spinner v-if="isHandle" />
    <div class="relative p-4 overflow-x-auto shadow-md sm:rounded-lg">
        <h3 class="text-2xl font-extrabold dark:text-white">Thêm đăng ký dịch vụ</h3>
        <br />
        <form @submit.prevent="addSubscription">
            <div class="mb-6">
                <label class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Khách hàng
                    <span class="text-red-600 text-sm">*</span>
                </label>
                <select v-model="subscription.patientId"
                    class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
                    <option disabled value="">Chọn khách hàng</option>
                    <option v-for="patient in patients" :key="patient.id" :value="patient.id">{{ patient.fullname }}
                    </option>
                </select>
            </div>
            <div class="mb-6">
                <label class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Dịch vụ
                    <span class="text-red-600 text-sm">*</span>
                </label>
                <select v-model="subscription.servicePackageId"
                    class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
                    <option disabled value="">Chọn gói dịch vụ</option>
                    <option v-for="pack in servicePackages" :key="pack.id" :value="pack.id">
                        {{ pack.serviceTypeName }}
                        - 
                        {{ pack.name }}  
                        - 
                        {{ formatPrice(pack.price) }} VND
                    </option>
                </select>
            </div>
            <button type="submit"
                class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">Thêm</button>
            <router-link to="/subscription"
                class="ml-3 font-medium text-blue-600 dark:text-blue-500 hover:underline">Quay
                lại</router-link>
        </form>
    </div>
</template>

<script>
import axios from 'axios';
import Spinner from '../Common/Spinner.vue';
export default {
    name: "AddSubscription",
    components: {
        Spinner
    },
    data() {
        const today = new Date();
        return {
            subscription: {
                patientId: '',
                servicePackageId: '',
                startDate: today.toISOString().substr(0, 10),
                endDate: today.toISOString().substr(0, 10),
            },
            patients: [],
            servicePackages: [],
            isHandle: false
        };
    },
    methods: {
        async addSubscription() {
            try {
                this.isHandle = true;
                const response = await fetch('https://localhost:7072/api/subscription', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(this.subscription),
                });

                if (response.ok) {
                    alert('Thêm đăng ký thành công!');
                    this.$router.push('/subscription');
                } else {
                    this.isHandle = false;
                    alert('Thêm đăng ký thất bại.');
                }
            } catch (error) {
                console.error('Error:', error);
                alert('Có lỗi xảy ra. Hãy thử lại.');
            }
        },
        async fetchData() {
            try {
                const res1 = await axios.get('https://localhost:7072/api/user/roles/3', {
                    params: {
                        pageNumber: 1,
                        pageSize: 100,
                    }
                });
                this.patients = res1.data.items;

                const res3 = await axios.get('https://localhost:7072/api/service/service-packages', {
                    params: {
                        pageNumber: 1,
                        pageSize: 100,
                    }
                });

                this.servicePackages = res3.data.items;
            } catch (error) {
                console.error("There was an error fetching the patients:", error);
            }
        },
        formatPrice(value) {
            return new Intl.NumberFormat('vi-VN').format(value);
        },
    },
    mounted() {
        this.fetchData();
    }
};
</script>