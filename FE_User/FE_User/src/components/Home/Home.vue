<script>
import axios from 'axios';
import AboutUs from './AboutUs.vue';
import Slider from './Slider.vue';
import Toast from '../Common/Toast.vue';
import AddSubscription from '../Service/AddSubscription.vue';

export default {
    name: "Home",
    components: {
        Slider,
        AboutUs,
        Toast,
        AddSubscription
    },
    data() {
        return {
            serviceTypes: [],
            isSuccessVisible: false,
            isErrorVisible: false,
            successMessage: '',
            errorMessage: '',
            isLogin: false,
        };
    },
    methods: {
        async fetchServiceTypes() {
            try {
                const response = await axios.get('https://localhost:7072/api/service/service-types', {
                    params: {
                        pageNumber: 1,
                        pageSize: 3,
                    }
                });
                this.serviceTypes = response.data.items;

                const backendUrl = 'https://localhost:7072';

                this.serviceTypes = this.serviceTypes.map(serviceType => {
                    if (serviceType.image) {
                        serviceType.image = `${backendUrl}${serviceType.image}`;
                    }
                    return serviceType;
                });

            } catch (error) {
                this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
            }
        },
        formatPrice(value) {
            return new Intl.NumberFormat('vi-VN').format(value);
        },
        showSuccessToast(message) {
            this.successMessage = message;
            this.isSuccessVisible = true;
            setTimeout(this.hideSuccessToast, 3000);
        },
        hideSuccessToast() {
            this.isSuccessVisible = false;
            localStorage.removeItem('loginSuccessMessage');
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
    mounted() {
        const message = localStorage.getItem('loginSuccessMessage');

        if (message) {
            this.successMessage = message;
            this.isSuccessVisible = true;

            // Set a timeout to hide the toast after 3 seconds
            setTimeout(() => {
                this.hideSuccessToast();
            }, 2000);
        }
        const role = localStorage.getItem('role');
         if (!role) {
            this.isLogin = false;
         }
         else if (role != "Patient") {
            this.isLogin = false;
         }
         else {
            this.isLogin = true;
         }
        this.fetchServiceTypes();

        //chatbot
        // (function(d, m){
        //     var kommunicateSettings = 
        //         {"appId":"1317ebac843b93c9e2659f7a167f382d5","popupWidget":true,"automaticChatOpenOnNavigation":true};
        //     var s = document.createElement("script"); s.type = "text/javascript"; s.async = true;
        //     s.src = "https://widget.kommunicate.io/v2/kommunicate.app";
        //     var h = document.getElementsByTagName("head")[0]; h.appendChild(s);
        //     window.kommunicate = m; m._globals = kommunicateSettings;
        // })(document, window.kommunicate || {});
        (function(d, m){
            var kommunicateSettings = 
                {"appId":"110a1bdaa81e8afd6ff7ec44fe594740a","popupWidget":true,"automaticChatOpenOnNavigation":true};
            var s = document.createElement("script"); s.type = "text/javascript"; s.async = true;
            s.src = "https://widget.kommunicate.io/v2/kommunicate.app";
            var h = document.getElementsByTagName("head")[0]; h.appendChild(s);
            window.kommunicate = m; m._globals = kommunicateSettings;
        })(document, window.kommunicate || {})
    }
}
</script>

<template>
    <Toast v-if="isSuccessVisible" :message="successMessage" :isVisible="isSuccessVisible" @close="hideSuccessToast" />
    <Toast v-if="isErrorVisible" :message="errorMessage" :isVisible="isErrorVisible" @close="hideErrorToast" />

    <section
        class="bg-center bg-no-repeat bg-[url('https://shrisaihospitals.com/ambala/wp-content/uploads/sites/5/2024/02/home-healthcare.jpg')] bg-gray-700 bg-blend-multiply">
        <div class="px-4 mx-auto max-w-screen-xl text-center py-12 lg:py-24">
            <h1 class="mb-4 text-4xl font-extrabold leading-none text-white md:text-5xl lg:text-6xl">
                Chăm Sóc Sức Khỏe Tận Tâm Tại Nhà
            </h1>
            <p class="mb-8 text-lg font-normal text-gray-300 lg:text-xl sm:px-16 lg:px-48">
                Tại Homecare, chúng tôi mang đến các dịch vụ chăm sóc sức khỏe chuyên nghiệp ngay tại ngôi nhà của bạn.
                Với đội ngũ y tế tận tâm và công nghệ hiện đại, chúng tôi cam kết cải thiện chất lượng cuộc sống và sức
                khỏe lâu dài, giúp bạn an tâm tận hưởng cuộc sống mà không cần lo lắng về vấn đề sức khỏe.
            </p>
            <div class="flex flex-col space-y-4 sm:flex-row sm:justify-center sm:space-y-0">
                <a href="#procedure"
                    class="inline-flex justify-center items-center py-3 px-5 text-base font-medium text-center text-white rounded-lg bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:ring-blue-300 dark:focus:ring-blue-900">
                    Bắt đầu ngay
                    <svg class="w-3.5 h-3.5 ms-2 rtl:rotate-180" aria-hidden="true" xmlns="http://www.w3.org/2000/svg"
                        fill="none" viewBox="0 0 14 10">
                        <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                            d="M1 5h12m0 0L9 1m4 4L9 9" />
                    </svg>
                </a>
                <a href="/contact"
                    class="inline-flex justify-center hover:text-gray-900 items-center py-3 px-5 sm:ms-4 text-base font-medium text-center text-white rounded-lg border border-white hover:bg-gray-100 focus:ring-4 focus:ring-gray-400">
                    Liên hệ
                </a>
            </div>
        </div>
    </section>

    <div v-if="isLogin" class="flex flex-col items-center bg-gray-100 dark:bg-gray-900 p-5">
        <h1
            class="mb-4 text-3xl font-semibold leading-none tracking-tight text-gray-900 md:text-5xl lg:text-3xl dark:text-white">
            Đăng ký dịch vụ ngay</h1>
        <div class="mt-2 items-center sm:flex">
            <AddSubscription />
        </div>
    </div>


    <div id="procedure" class="mt-5 flex flex-col items-center">
        <h1
            class="mb-4 text-3xl font-semibold leading-none tracking-tight text-gray-900 md:text-5xl lg:text-3xl dark:text-white">
            Quy trình sử dụng dịch vụ</h1>
        <ol class="mt-2 items-center sm:flex">
            <li class="relative mb-6 sm:mb-0">
                <div class="flex items-center">
                    <div
                        class="z-10 flex items-center justify-center w-6 h-6 bg-blue-100 rounded-full ring-0 ring-white dark:bg-blue-900 sm:ring-8 dark:ring-gray-900 shrink-0">
                        <svg class="w-4 h-4 text-blue-800 dark:text-blue-300" aria-hidden="true"
                            xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 24 24">
                            <path
                                d="M17.133 12.632v-1.8a5.406 5.406 0 0 0-4.154-5.262.955.955 0 0 0 .021-.106V3.1a1 1 0 0 0-2 0v2.364a.955.955 0 0 0 .021.106 5.406 5.406 0 0 0-4.154 5.262v1.8C6.867 15.018 5 15.614 5 16.807 5 17.4 5 18 5.538 18h12.924C19 18 19 17.4 19 16.807c0-1.193-1.867-1.789-1.867-4.175ZM6 6a1 1 0 0 1-.707-.293l-1-1a1 1 0 0 1 1.414-1.414l1 1A1 1 0 0 1 6 6Zm-2 4H3a1 1 0 0 1 0-2h1a1 1 0 1 1 0 2Zm14-4a1 1 0 0 1-.707-1.707l1-1a1 1 0 1 1 1.414 1.414l-1 1A1 1 0 0 1 18 6Zm3 4h-1a1 1 0 1 1 0-2h1a1 1 0 1 1 0 2ZM8.823 19a3.453 3.453 0 0 0 6.354 0H8.823Z" />
                        </svg>
                    </div>
                    <div class="hidden sm:flex w-full bg-gray-200 h-0.5 dark:bg-gray-700"></div>
                </div>
                <div class="mt-3 sm:pe-8">
                    <h3 class="text-sm font-semibold text-gray-900 dark:text-white">Đăng ký gói dịch vụ</h3>
                </div>
            </li>
            <li class="relative mb-6 sm:mb-0">
                <div class="flex items-center">
                    <div
                        class="z-10 flex items-center justify-center w-6 h-6 bg-blue-100 rounded-full ring-0 ring-white dark:bg-blue-900 sm:ring-8 dark:ring-gray-900 shrink-0">
                        <svg class="w-4 h-4 text-blue-800 dark:text-blue-300" aria-hidden="true"
                            xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 24 24">
                            <path fill-rule="evenodd"
                                d="M7 6a2 2 0 0 1 2-2h11a2 2 0 0 1 2 2v7a2 2 0 0 1-2 2h-2v-4a3 3 0 0 0-3-3H7V6Z"
                                clip-rule="evenodd" />
                            <path fill-rule="evenodd"
                                d="M2 11a2 2 0 0 1 2-2h11a2 2 0 0 1 2 2v7a2 2 0 0 1-2 2H4a2 2 0 0 1-2-2v-7Zm7.5 1a2.5 2.5 0 1 0 0 5 2.5 2.5 0 0 0 0-5Z"
                                clip-rule="evenodd" />
                            <path d="M10.5 14.5a1 1 0 1 1-2 0 1 1 0 0 1 2 0Z" />
                        </svg>

                    </div>
                    <div class="hidden sm:flex w-full bg-gray-200 h-0.5 dark:bg-gray-700"></div>
                </div>
                <div class="mt-3 sm:pe-8">
                    <h3 class="text-sm font-semibold text-gray-900 dark:text-white">Thanh toán</h3>
                </div>
            </li>
            <li class="relative mb-6 sm:mb-0">
                <div class="flex items-center">
                    <div
                        class="z-10 flex items-center justify-center w-6 h-6 bg-blue-100 rounded-full ring-0 ring-white dark:bg-blue-900 sm:ring-8 dark:ring-gray-900 shrink-0">
                        <svg class="w-4 h-4 text-blue-800 dark:text-blue-300" aria-hidden="true"
                            xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 24 24">
                            <path fill-rule="evenodd"
                                d="M18 5.05h1a2 2 0 0 1 2 2v2H3v-2a2 2 0 0 1 2-2h1v-1a1 1 0 1 1 2 0v1h3v-1a1 1 0 1 1 2 0v1h3v-1a1 1 0 1 1 2 0v1Zm-15 6v8a2 2 0 0 0 2 2h14a2 2 0 0 0 2-2v-8H3ZM11 18a1 1 0 1 0 2 0v-1h1a1 1 0 1 0 0-2h-1v-1a1 1 0 1 0-2 0v1h-1a1 1 0 1 0 0 2h1v1Z"
                                clip-rule="evenodd" />
                        </svg>
                    </div>
                    <div class="hidden sm:flex w-full bg-gray-200 h-0.5 dark:bg-gray-700"></div>
                </div>
                <div class="mt-3 sm:pe-8">
                    <h3 class="text-sm font-semibold text-gray-900 dark:text-white">Đặt lịch hẹn</h3>
                </div>
            </li>
            <li class="relative mb-6 sm:mb-0">
                <div class="flex items-center">
                    <div
                        class="z-10 flex items-center justify-center w-6 h-6 bg-blue-100 rounded-full ring-0 ring-white dark:bg-blue-900 sm:ring-8 dark:ring-gray-900 shrink-0">
                        <svg class="w-4 h-4 text-blue-800 dark:text-blue-300" aria-hidden="true"
                            xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor"
                            viewBox="0 0 24 24">
                            <path fill-rule="evenodd"
                                d="M18 14a1 1 0 1 0-2 0v2h-2a1 1 0 1 0 0 2h2v2a1 1 0 1 0 2 0v-2h2a1 1 0 1 0 0-2h-2v-2Z"
                                clip-rule="evenodd" />
                            <path fill-rule="evenodd"
                                d="M15.026 21.534A9.994 9.994 0 0 1 12 22C6.477 22 2 17.523 2 12S6.477 2 12 2c2.51 0 4.802.924 6.558 2.45l-7.635 7.636L7.707 8.87a1 1 0 0 0-1.414 1.414l3.923 3.923a1 1 0 0 0 1.414 0l8.3-8.3A9.956 9.956 0 0 1 22 12a9.994 9.994 0 0 1-.466 3.026A2.49 2.49 0 0 0 20 14.5h-.5V14a2.5 2.5 0 0 0-5 0v.5H14a2.5 2.5 0 0 0 0 5h.5v.5c0 .578.196 1.11.526 1.534Z"
                                clip-rule="evenodd" />
                        </svg>

                    </div>
                    <div class="hidden sm:flex w-full bg-gray-200 h-0.5 dark:bg-gray-700"></div>
                </div>
                <div class="mt-3 sm:pe-8">
                    <h3 class="text-sm font-semibold text-gray-900 dark:text-white">Sử dụng dịch vụ</h3>
                </div>
            </li>
        </ol>
    </div>

    <Slider />

    <div class="mt-5 flex flex-col items-center">
        <h1 class="mb-4 text-3xl font-semibold leading-none text-gray-900 md:text-5xl lg:text-3xl dark:text-white">
            Dịch vụ của chúng tôi</h1>

        <div class="p-2 mb-5 grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
            <div v-for="service in serviceTypes" :key="service.id"
                class="w-full max-w-sm bg-white border border-gray-200 rounded-lg shadow dark:bg-gray-800 dark:border-gray-700">
                <img class="rounded-t-lg h-64" :src="service.image" alt="product image" />
                <div class="px-5 pb-5">
                    <h5 class="text-lg font-semibold text-gray-900 dark:text-white mt-2">
                        {{ service.name }} <!-- Assuming each service has a name -->
                    </h5>
                    <div class="flex items-center justify-between">
                        <span class="text-xl font-bold text-gray-900 dark:text-white">
                            {{ formatPrice(service.sessionPrice) }} VNĐ</span>
                        <!-- Assuming price is a string -->
                        <a :href="`/service/${service.id}`"
                            class="text-gray-900 bg-white border border-gray-300 focus:outline-none hover:bg-gray-100 focus:ring-4 focus:ring-gray-100 font-medium rounded-lg text-sm px-5 py-2.5 dark:bg-gray-800 dark:text-white dark:border-gray-600 dark:hover:bg-gray-700 dark:hover:border-gray-600 dark:focus:ring-gray-700">
                            Xem chi tiết
                        </a>
                    </div>
                </div>
            </div>
        </div>
        <router-link to="/service" type="button"
            class="text-gray-900 bg-white border border-gray-300 focus:outline-none hover:bg-gray-100 focus:ring-4 focus:ring-gray-100 font-medium rounded-full text-sm px-5 py-2.5 me-2 mb-2 dark:bg-gray-800 dark:text-white dark:border-gray-600 dark:hover:bg-gray-700 dark:hover:border-gray-600 dark:focus:ring-gray-700">
            <div class="flex items-center space-x-2">
                <span class="text-gray-700 dark:text-white">Xem thêm</span>
                <svg class="w-6 h-6 text-gray-800 dark:text-white" aria-hidden="true" xmlns="http://www.w3.org/2000/svg"
                    width="24" height="24" fill="none" viewBox="0 0 24 24">
                    <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                        d="M19 12H5m14 0-4 4m4-4-4-4" />
                </svg>
            </div>

        </router-link>
    </div>

    <hr class="h-px my-8 bg-gray-200 border-0 dark:bg-gray-700">

    <AboutUs />
</template>
