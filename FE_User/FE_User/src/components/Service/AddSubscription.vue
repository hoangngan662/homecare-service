<template>
    <Spinner v-if="isHandle" />
    <Toast v-if="isSuccessVisible" :message="successMessage" :isVisible="isSuccessVisible" @close="hideSuccessToast" />
    <Toast v-if="isErrorVisible" :message="errorMessage" :isVisible="isErrorVisible" @close="hideErrorToast" />

    <form class="max-w-full">
        <div class="flex space-x-10">
            <div class="flex-1">
                <label for="services" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">
                    Chọn dịch vụ
                </label>
                <select id="services" v-model="selectedServiceId" @change="updateServicePackages"
                    class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-fit p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
                    <option disabled value="">Chọn dịch vụ</option>
                    <option v-for="service in serviceTypes" :key="service.id" :value="service.id">
                        {{ service.name }}
                    </option>
                </select>
            </div>

            <div class="flex-1">
                <label for="servicePackages" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">
                    Chọn gói dịch vụ
                </label>
                <select id="servicePackages" v-model="selectedPackageId" @change="updateSelectedPackage"
                    class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-fit p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
                    <option disabled value="">Chọn gói dịch vụ</option>
                    <option v-for="pack in filteredServicePackages" :key="pack.id" :value="pack.id">
                        {{ pack.name }} - {{ pack.price.toLocaleString() }} VND
                    </option>
                </select>
            </div>

            <div class="flex-1 flex items-end">
                <button type="button" @click="openModal"
                    class="text-white bg-blue-700 hover:bg-blue-800 focus:outline-none focus:ring-4 focus:ring-blue-300 font-medium rounded-full text-sm px-5 py-2.5 text-center me-2 dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">
                    Đăng ký ngay
                </button>
            </div>
        </div>
    </form>
    <div v-show="isOpen" tabindex="-1" aria-hidden="true" @click.self="closeModal"
        class="fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-50">
        <div class="relative w-full max-w-lg max-h-full bg-white rounded-lg shadow dark:bg-gray-700">
            <div class="flex items-center justify-between p-4 md:p-5 border-b rounded-t dark:border-gray-600">
                <h3 class="text-lg font-semibold text-gray-900 dark:text-white">
                    Thông tin đăng ký dịch vụ
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
            <form v-if="selectedPackage" class="p-4 md:p-5" @submit.prevent="registerPackage">
                <div class="grid gap-2 mb-2">
                    <div class="col-span-2 flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Khách hàng:</label>
                        <div class="flex-1 text-left">{{ patientName }}</div>
                    </div>
                    <div class="col-span-2 flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Dịch vụ:</label>
                        <div class="flex-1 text-left">{{ service.name }}</div>
                    </div>
                    <div class="col-span-2 flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Gói dịch vụ:</label>
                        <div class="flex-1 text-left">{{ selectedPackage.name }}</div>
                    </div>
                    <div class="col-span-2 flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Thời hạn:</label>
                        <div class="flex-1 text-left">
                            {{ selectedPackage.numberOfSessions }} buổi
                            /
                            {{ selectedPackage.durationInMonths }} tháng
                        </div>
                    </div>
                    <div class="col-span-2 flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Giá:</label>
                        <div class="flex-1 text-left">{{ formatPrice(selectedPackage.price) }} VNĐ</div>
                    </div>
                </div>
                <button type="submit"
                    class="text-white inline-flex items-center bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">
                    Đăng ký
                </button>
            </form>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
import Toast from '../Common/Toast.vue';
import Spinner from '../Common/Spinner.vue';

export default {
    name: "AddSubscription",
    components: {
        Toast,
        Spinner
    },
    data() {
        const today = new Date();
        return {
            serviceTypes: [],
            selectedServiceId: "",
            servicePackages: [],
            filteredServicePackages: [],
            selectedPackageId: "", 
            selectedPackage: null, // Holds the currently selected package
            patientName: 'Tên bệnh nhân', // Placeholder for the patient's name
            service: {}, // Holds the selected service details
            isSuccessVisible: false,
            isErrorVisible: false,
            successMessage: '',
            errorMessage: '',
            subscription: {
                patientId: '', // Set this according to your patient data
                servicePackageId: '',
                startDate: today.toISOString().substr(0, 10),
                endDate: today.toISOString().substr(0, 10),
            },
            isOpen: false,
            isHandle: false,
        };
    },

    methods: {
        async fetchServiceTypes() {
            try {
                const response = await axios.get(`https://localhost:7072/api/service/service-types`, {
                    params: {
                        pageNumber: 1,
                        pageSize: 100
                    }
                });
                this.serviceTypes = response.data.items;
                this.patientName = localStorage.getItem('fullname');
            } catch (error) {
                this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
            }
        },
        updateServicePackages() {
            const selectedService = this.serviceTypes.find(service => service.id === parseInt(this.selectedServiceId));
            this.service = selectedService || {}; // Set the service property
            this.filteredServicePackages = selectedService ? selectedService.servicePackages : [];
            this.selectedPackageId = ""; // Reset selection for service packages
            this.selectedPackage = null; // Clear previously selected package
        },
        updateSelectedPackage() {
            this.selectedPackage = this.filteredServicePackages.find(pack => pack.id === parseInt(this.selectedPackageId));
        },
        async registerPackage() {
            this.isHandle = true;
            if (!this.selectedServiceId || !this.selectedPackageId) {
                this.showErrorToast("Vui lòng chọn dịch vụ và gói dịch vụ.");
                return;
            }
            try {
                this.subscription.servicePackageId = this.selectedPackageId;
                this.subscription.patientId = localStorage.getItem('id');
                const response = await fetch('https://localhost:7072/api/subscription', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(this.subscription),
                });

                if (response.ok) {
                    const data = await response.json();
                    const reqData = {
                        orderId: data.id,
                        amount: data.total
                    };
                    const res2 = await fetch('https://localhost:7072/api/payment/create', {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json',
                        },
                        body: JSON.stringify(reqData),
                    });

                    if (res2.ok) {
                        const data1 = await res2.json();
                        const paymentUrl = data1.paymentUrl;
                        window.location.href = paymentUrl;
                    } else {
                        console.error('Thanh toán thất bại. Hãy thử lại.');
                    }
                } else {
                    this.showErrorToast("Bạn đã có 2 gói dịch vụ chưa thanh toán, vui lòng thanh toán hoặc hủy trước khi đăng ký gói mới.");
                }                
            } catch (error) {
                this.showErrorToast('Đã xảy ra lỗi trong quá trình đăng ký. Vui lòng thử lại.');
            }
            finally{
                this.isHandle = false;
            }
        },
        showErrorToast(message) {
            this.errorMessage = message;
            this.isErrorVisible = true;
            setTimeout(() => {
                this.isErrorVisible = false;
            }, 3000);
        },
        hideErrorToast() {
            this.isErrorVisible = false;
        },
        formatPrice(price) {
            return price.toLocaleString();
        },
        closeModal() {
            this.isOpen = false;
        },
        openModal() {
            if (!this.selectedServiceId || !this.selectedPackageId) {
                this.showErrorToast("Vui lòng chọn dịch vụ và gói dịch vụ.");
                return;
            }
            this.isOpen = true;
        }
    },

    mounted() {
        this.fetchServiceTypes();
    }
};
</script>

<style scoped>
/* Add scoped CSS if needed */
</style>
