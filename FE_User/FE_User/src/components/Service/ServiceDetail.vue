<template>
    <Spinner v-if="isHandle" />
    <Toast v-if="isSuccessVisible" :message="successMessage" :isVisible="isSuccessVisible" @close="hideSuccessToast" />
    <Toast v-if="isErrorVisible" :message="errorMessage" :isVisible="isErrorVisible" @close="hideErrorToast" />

    <div class="relative p-4 overflow-x-auto shadow-md sm:rounded-lg">
        <!-- Breadcrumb -->
        <nav class="flex px-5 py-3 text-gray-700 border border-gray-200 rounded-lg bg-gray-50 dark:bg-gray-800 dark:border-gray-700"
            aria-label="Breadcrumb">
            <ol class="inline-flex items-center space-x-1 md:space-x-2 rtl:space-x-reverse">
                <li class="inline-flex items-center">
                    <a href="/"
                        class="inline-flex items-center text-sm font-medium text-gray-700 hover:text-blue-600 dark:text-gray-400 dark:hover:text-white">
                        <svg class="w-3 h-3 me-2.5" aria-hidden="true" xmlns="http://www.w3.org/2000/svg"
                            fill="currentColor" viewBox="0 0 20 20">
                            <path
                                d="m19.707 9.293-2-2-7-7a1 1 0 0 0-1.414 0l-7 7-2 2a1 1 0 0 0 1.414 1.414L2 10.414V18a2 2 0 0 0 2 2h3a1 1 0 0 0 1-1v-4a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v4a1 1 0 0 0 1 1h3a2 2 0 0 0 2-2v-7.586l.293.293a1 1 0 0 0 1.414-1.414Z" />
                        </svg>
                        Trang chủ
                    </a>
                </li>
                <li>
                    <div class="flex items-center">
                        <svg class="rtl:rotate-180 block w-3 h-3 mx-1 text-gray-400 " aria-hidden="true"
                            xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 6 10">
                            <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                d="m1 9 4-4-4-4" />
                        </svg>
                        <a href="/service"
                            class="ms-1 text-sm font-medium text-gray-700 hover:text-blue-600 md:ms-2 dark:text-gray-400 dark:hover:text-white">Dịch
                            vụ</a>
                    </div>
                </li>
                <li aria-current="page">
                    <div class="flex items-center">
                        <svg class="rtl:rotate-180  w-3 h-3 mx-1 text-gray-400" aria-hidden="true"
                            xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 6 10">
                            <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                d="m1 9 4-4-4-4" />
                        </svg>
                        <span class="ms-1 text-sm font-medium text-gray-500 md:ms-2 dark:text-gray-400">{{
                            service.name
                            }}</span>
                    </div>
                </li>
            </ol>
        </nav>

        <div class="mt-4 grid grid-cols-2 gap-5">
            <div>
                <img class="h-auto max-w-full rounded-lg mb-5" :src="service.image" alt="">

                <router-link to="/service" class="flex items-center space-x-2">
                    <svg class="w-6 h-6 text-gray-800 dark:text-white" aria-hidden="true"
                        xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none" viewBox="0 0 24 24">
                        <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                            d="M5 12h14M5 12l4-4m-4 4 4 4" />
                    </svg>
                    <span class="text-gray-700 dark:text-white">Quay lại</span>
                </router-link>
            </div>
            <div>
                <h5 class="mb-4 text-2xl font-bold text-gray-900 dark:text-white">
                    {{ service.name }}
                </h5>
                <span
                    class=" bg-blue-100 text-blue-800 text-sm font-medium me-2 px-2.5 py-0.5 rounded dark:bg-blue-900 dark:text-blue-300">Mô
                    tả</span>
                <p class="mb-3 font-normal text-gray-700 dark:text-gray-400">
                    {{ service.description }}
                </p>
                <span class="font-bold text-gray-700 dark:text-white">Các gói dịch vụ</span>
                <div class="mt-4 grid grid-cols-3 gap-2">
                    <label v-for="pack in servicePackages" :key="pack.id"
                        class="block max-w-sm p-2 bg-white border border-gray-200 rounded-lg shadow hover:bg-gray-100 dark:bg-gray-800 dark:border-gray-700 dark:hover:bg-gray-700">
                        <input type="radio" name="service" class="mr-2" @change="handleSelectPackage(pack)">
                        <h5 class="text-md font-bold tracking-tight text-gray-900 dark:text-white">
                            {{ pack.name }}
                        </h5>
                        <p class="font-normal text-gray-700 dark:text-gray-400">
                            {{ pack.numberOfSessions }} buổi
                            /
                            {{ pack.durationInMonths }} tháng
                        </p>
                        <p class="font-bold text-md text-gray-700 dark:text-white">
                            {{ formatPrice(pack.price) }} VNĐ
                        </p>
                    </label>
                </div>
                <button type="button" @click="openModal"
                    class="w-full mt-4 text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 me-2 mb-2 dark:bg-blue-600 dark:hover:bg-blue-700 focus:outline-none dark:focus:ring-blue-800">
                    Đăng ký
                </button>
            </div>
        </div>
    </div>
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
                            {{ selectedPackage.durationInMonths }} tháng</div>
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
import Spinner from '../Common/Spinner.vue';
import Toast from '../Common/Toast.vue';
export default {
    name: "ServiceDetail",
    components: {
        Spinner,
        Toast
    },
    data() {
        const today = new Date();
        return {
            service: {
                name: '',
                description: '',
                image: ''
            },
            servicePackages: [],
            serviceId: '',
            selectedPackage: null,
            isOpen: false,
            subscription: {
                patientId: '',
                servicePackageId: '',
                startDate: today.toISOString().substr(0, 10),
                endDate: today.toISOString().substr(0, 10),
            },
            patientName: '',
            isHandle: false,
            isSuccessVisible: false,
            isErrorVisible: false,
            successMessage: '',
            errorMessage: '',
        };
    },
    mounted() {
        this.fetchData();
    },
    methods: {
        async fetchData() {
            this.serviceId = this.$route.params.id;
            try {
                const response = await fetch(`https://localhost:7072/api/service/service-types/${this.serviceId}`);
                if (response.ok) {
                    const data = await response.json();
                    const backendUrl = 'https://localhost:7072';
                    this.service = {
                        name: data.name,
                        description: data.description,
                        image: data.image ? `${backendUrl}${data.image}` : '',
                    };
                    this.servicePackages = data.servicePackages;
                } else {
                    this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
                    this.$router.push('/service');
                }
                this.patientName = localStorage.getItem('fullname');
                this.subscription.patientId = localStorage.getItem('id');
            } catch (error) {
                this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
                this.$router.push('/service');
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
        formatPrice(value) {
            return new Intl.NumberFormat('vi-VN').format(value);
        },
        openModal() {
            const role = localStorage.getItem('role');
            if (!role) {
                localStorage.setItem('registerMessage', "Vui lòng đăng nhập để tiếp tục.");
                this.$router.push('/login');
            }
            else if (role != "Patient") {
                localStorage.setItem('registerMessage', "Vui lòng đăng nhập để tiếp tục.");
                this.$router.push('/login');
            }
            else if(this.selectedPackage == null){
                this.showErrorToast("Vui lòng chọn gói dịch vụ muốn đăng ký.");
            }
            else {
                this.isOpen = true;
            }
        },
        closeModal() {
            this.isOpen = false;
        },
        handleSelectPackage(pack) {
            this.selectedPackage = pack;
        },
        async registerPackage() {
            this.isHandle = true;
            this.subscription.servicePackageId = this.selectedPackage.id;
            try {
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
                this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
            }
            finally{
                this.isHandle = false;
            }
        }
    },
}
</script>