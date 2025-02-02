<script>
import Toast from '../Common/Toast.vue';
import StaffReview from './StaffReview.vue';
export default {
    name: "StaffDetail",
    components: {
        Toast,
        StaffReview
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
        };
    },
    mounted() {
        this.fetchStaff();
    },
    methods: {
        async fetchStaff() {
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
                } else {
                    this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
                    this.$router.push('/staff');
                }
            } catch (error) {
                this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
                this.$router.push('/staff');
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
        formatDate(dateString) {
            if (!dateString) return '';
            const date = new Date(dateString);
            return date.toISOString().split('T')[0];
        },
        formatDateForSubmission(dateString) {
            return new Date(dateString).toISOString();
        },
    }
}
</script>
<template>
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
                        <a href="/staff"
                            class="ms-1 text-sm font-medium text-gray-700 hover:text-blue-600 md:ms-2 dark:text-gray-400 dark:hover:text-white">
                            Nhân viên
                        </a>
                    </div>
                </li>
                <li aria-current="page">
                    <div class="flex items-center">
                        <svg class="rtl:rotate-180  w-3 h-3 mx-1 text-gray-400" aria-hidden="true"
                            xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 6 10">
                            <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                d="m1 9 4-4-4-4" />
                        </svg>
                        <span class="ms-1 text-sm font-medium text-gray-500 md:ms-2 dark:text-gray-400">
                            {{ this.staff.fullname }}
                        </span>
                    </div>
                </li>
            </ol>
        </nav>

        <div class="mt-4 grid grid-cols-2">
            <div class="w-auto">
                <img class="h-auto max-w-full rounded-lg mb-5"
                    src="https://cdn-icons-png.flaticon.com/512/6069/6069189.png"
                    alt="">

                <router-link to="/staff" class="flex items-center space-x-2">
                    <svg class="w-6 h-6 text-gray-800 dark:text-white" aria-hidden="true"
                        xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none" viewBox="0 0 24 24">
                        <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                            d="M5 12h14M5 12l4-4m-4 4 4 4" />
                    </svg>
                    <span class="text-gray-700 dark:text-white">Quay lại</span>
                </router-link>
            </div>
            <div class="w-full">
                <h5 class="mb-4 text-2xl font-bold text-gray-900 dark:text-white">
                    {{ staff.fullname }}
                </h5>
                <span
                    class=" bg-blue-100 text-blue-800 text-sm font-medium me-2 px-2.5 py-0.5 rounded dark:bg-blue-900 dark:text-blue-300">
                    Chuyên môn
                </span>
                <p class="mb-3 font-normal text-gray-700 dark:text-gray-400">
                    {{ staff.specialization }}
                </p>
                <StaffReview/>
            </div>
        </div>
    </div>
</template>