<template>
    <Toast v-if="isSuccessVisible" :message="successMessage" :isVisible="isSuccessVisible" @close="hideSuccessToast" />
    <Toast v-if="isErrorVisible" :message="errorMessage" :isVisible="isErrorVisible" @close="hideErrorToast" />

    <div class="relative m-4 p-4 overflow-x-auto shadow-md sm:rounded-lg">
        <h3 class="text-2xl font-extrabold dark:text-white">Hồ sơ khám bệnh</h3>
        <br />
        <div class="grid grid-cols-1 sm:grid-cols-2 gap-4">
            <section v-if="patientRecords.length !== 0" v-for="record in patientRecords" :key="record.serviceType"
                class="bg-white dark:bg-gray-900 antialiased mb-6 p-4 rounded-lg">
                <div class="flex justify-between items-center cursor-pointer"
                    @click="toggleAccordion(record.serviceType)">
                    <h4 class="text-xl font-semibold text-gray-800 dark:text-white">{{ record.serviceType }}</h4>
                    <svg data-accordion-icon class="w-3 h-3 shrink-0"
                        :class="{ 'rotate-180': isOpen(record.serviceType) }" aria-hidden="true"
                        xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 10 6">
                        <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                            d="M1 1l4 4 4-4" />
                    </svg>
                </div>
                <div v-if="isOpen(record.serviceType)" class="mt-4">
                    <div class="flow-root mx-auto">
                        <div v-for="(appointment, index) in record.appointments" :key="appointment.id"
                            class="my-4 py-4 border-b border-gray-200 dark:border-gray-700">
                            <div class="flex flex-col sm:flex-row sm:items-center gap-2 sm:gap-6">
                                <p
                                    class="w-32 text-lg font-normal text-gray-500 sm:text-right dark:text-gray-400 shrink-0">
                                <div class="font-semibold text-3xl text-gray-900 dark:text-white">
                                    # {{ index + 1 }}
                                </div>
                                <span class="text-md">
                                    {{ formatDate(appointment.appointmentDate) }}
                                    <br />
                                    {{ appointment.shiftTime }}
                                </span>

                                </p>
                                <div>
                                    <h3 class="text-md font-semibold text-gray-900 dark:text-white">
                                        Nhân viên: {{ appointment.staffFullName}}
                                    </h3>
                                    <p class="text-gray-700 dark:text-gray-400">
                                        Gói dịch vụ: {{ appointment.servicePackageName }}
                                    </p>
                                    <p class="text-gray-700 dark:text-gray-400">
                                        Tình trạng bệnh nhân: {{ appointment.appointmentDetailDto.patientCondition}}
                                    </p>
                                    <p class="text-gray-700 dark:text-gray-400">
                                        Chi tiết: {{ appointment.appointmentDetailDto.treatmentProvided}}
                                    </p>
                                    <p class="text-gray-700 dark:text-gray-400">
                                        Lưu ý: {{ appointment.appointmentDetailDto.notes}}
                                    </p>
                                    <p class="text-gray-700 dark:text-gray-400">
                                        Ngày hẹn đề xuất: {{
                                        formatDate(appointment.appointmentDetailDto.nextAppointmentDate)}}
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <div v-else>
                Chưa có hồ sơ khám bệnh
            </div>
        </div>
        <BottomNav />
    </div>
</template>

<script>
import Toast from '../Common/Toast.vue';
import BottomNav from './BottomNav.vue';

export default {
    name: "UserRecord",
    components: {
        BottomNav,
        Toast
    },
    data() {
        return {
            patientRecords: [],
            openSections: new Set(),
            isSuccessVisible: false,
            isErrorVisible: false,
            successMessage: '',
            errorMessage: '',
        };
    },
    methods: {
        async fetchPatientRecords() {
            try {
                const patientId = localStorage.getItem('id');
                if (!patientId) {
                    localStorage.setItem('registerMessage', "Vui lòng đăng nhập để tiếp tục.");
                    this.$router.push('/login');
                    return;
                }

                const response = await fetch(`https://localhost:7072/api/appointment/record?patientId=${patientId}`);

                if (!response.ok) {
                    this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
                }
                this.patientRecords = await response.json();
                console.log(this.patientRecords);
                
            } catch (error) {
                this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
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
        toggleAccordion(serviceType) {
            if (this.openSections.has(serviceType)) {
                this.openSections.delete(serviceType);
            } else {
                this.openSections.add(serviceType);
            }
        },
        isOpen(serviceType) {
            return this.openSections.has(serviceType);
        },
        formatDate(dateString) {
            const date = new Date(dateString);
            return date.toLocaleDateString('vi-VN', { day: '2-digit', month: '2-digit', year: 'numeric' });
        }
    },
    mounted() {
        this.fetchPatientRecords();
    }
}
</script>

<style scoped>
/* Thêm style nếu cần */
</style>
