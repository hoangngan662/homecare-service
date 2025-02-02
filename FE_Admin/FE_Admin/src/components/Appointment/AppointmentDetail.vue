<script>
import Spinner from '../Common/Spinner.vue';
import axios from 'axios';
export default {
    name: 'AppointmentDetail',
    components: {
        Spinner
    },
    data() {
        return {
            appointment: {
                subscriptionId: '',
                patientFullName: '',
                staffId: '',
                staffFullName: '',
                shiftId: '',
                shiftTime: '',                
                servicePackageName: '',
                appointmentDate: '',
                status: '',
                address: '',
                phone: '',
                note: ''
            },
            appointmentId: '',
            appointmentDetail: {
                appointmentId: '',
                patientCondition: '',
                treatmentProvided: '',
                notes: '',
                nextAppointmentDate: '',
            },
            review: {
                appointmentRating: 5,
                appointmentComment: '',
                staffRating: 5,
                staffComment: '',
                reviewDate: '',
            },
        };
    },
    mounted() {
        this.fetchData();
    },
    methods: {
        async fetchData() {
            this.appointmentId = this.$route.params.id;
            try {
                const response = await fetch(`https://localhost:7072/api/appointment/${this.appointmentId}`);
                if (response.ok) {
                    const data = await response.json();
                    console.log(data);

                    this.appointment = {
                        ...data,
                        servicePackageName: data.serviceTypeName + " - " + data.servicePackageName,
                        startDate: new Date(data.startDate).toLocaleDateString('en-GB'),
                        endDate: new Date(data.endDate).toLocaleDateString('en-GB'),
                        appointmentDate: new Date(data.appointmentDate).toLocaleDateString('en-GB')
                    };
                    if (data.appointmentDetailDto) {
                        this.appointmentDetail = data.appointmentDetailDto;
                    }
                    if (data.appointmentReviewDto) {
                        this.review = data.appointmentReviewDto;
                    }
                    
                } else {
                    alert('Có lỗi xảy ra. Hãy thử lại.');
                    this.$router.push('/');
                }
            } catch (error) {
                alert('Có lỗi xảy ra. Hãy thử lại.');
                this.$router.push('/');
            }
        },
        formatDate(dateString) {
            const date = new Date(dateString);
            return date.toLocaleDateString('vi-VN', { day: '2-digit', month: '2-digit', year: 'numeric' });
        }
    },
}
</script>

<template>
    <div class="relative p-4 overflow-x-auto shadow-md sm:rounded-lg">
        <h3 class="text-2xl font-extrabold dark:text-white">Chi tiết lịch hẹn</h3>
        <br />
        <div class="grid gap-2 mb-2 p-2">
            <div class="col-span-2 flex items-center">
                <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Mã đăng ký dịch vụ:</label>
                <div class="flex-1 text-left">{{ appointment.subscriptionId }}</div>
            </div>
            <div class="col-span-2 flex items-center">
                <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Dịch vụ:</label>
                <div class="flex-1 text-left">{{ appointment.servicePackageName }}</div>
            </div>
            <div class="col-span-2 flex items-center">
                <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Bệnh nhân:</label>
                <div class="flex-1 text-left">{{ appointment.patientFullName }}</div>
            </div>
            <div class="col-span-2 flex items-center">
                <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Nhân viên:</label>
                <div class="flex-1 text-left">
                    <div class="flex-1 text-left">{{ appointment.staffFullName }}</div>
                </div>
            </div>
            <div class="col-span-2 flex items-center">
                <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Ngày hẹn:</label>
                <div class="flex-1 text-left">
                    <div class="flex-1 text-left">{{ formatDate(appointment.appointmentDate) }}</div>
                </div>
            </div>
            <div class="col-span-2 flex items-center">
                <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Ca hẹn:</label>
                <div class="flex-1 text-left">
                    <div class="flex-1 text-left">{{ appointment.shiftTime }}</div>
                </div>
            </div>
            <div class="col-span-2 flex items-center">
                <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Địa chỉ:</label>
                <div class="flex-1 text-left">
                    <div class="flex-1 text-left">{{ appointment.address }}</div>
                </div>
            </div>
            <div class="col-span-2 flex items-center">
                <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Số điện thoại:</label>
                <div class="flex-1 text-left">
                    <div class="flex-1 text-left">{{ appointment.phone }}</div>
                </div>
            </div>
            <div class="col-span-2 flex items-center">
                <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Trạng thái:</label>
                <div class="flex-1 text-left">
                    <div class="flex-1 text-left">
                        <span v-if="appointment.status === 'Pending'"
                            class="bg-yellow-100 text-yellow-800 text-xs font-medium px-2.5 py-0.5 rounded-full dark:bg-yellow-900 dark:text-yellow-300">
                            Chờ xử lý
                        </span>
                        <span v-else-if="appointment.status === 'Scheduled'"
                            class="bg-green-100 text-green-800 text-xs font-medium px-2.5 py-0.5 rounded-full dark:bg-green-900 dark:text-green-300">
                            Đã lên lịch
                        </span>
                        <span v-else-if="appointment.status === 'Completed'"
                            class="bg-blue-100 text-blue-800 text-xs font-medium px-2.5 py-0.5 rounded-full dark:bg-blue-900 dark:text-blue-300">
                            Hoàn thành
                        </span>
                        <span v-else-if="appointment.status === 'Cancelled'"
                            class="bg-red-100 text-red-800 text-xs font-medium px-2.5 py-0.5 rounded-full dark:bg-red-900 dark:text-red-300">
                            Hủy
                        </span>
                        <span v-else
                            class="bg-gray-100 text-gray-800 text-xs font-medium px-2.5 py-0.5 rounded-full dark:bg-gray-900 dark:text-gray-300">
                            Default
                        </span>
                    </div>
                </div>
            </div>
            <div class="col-span-2 flex items-center">
                <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Ghi chú:</label>
                <div class="flex-1 text-left">
                    <div class="flex-1 text-left">{{ appointment.note }}</div>
                </div>
            </div>
        </div>
        <div v-if="appointment.appointmentDetailDto" class="grid gap-2 mb-2 p-2 grid-cols-2">
            <div>
                <div class="flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Tình trạng bệnh nhân:</label>
                    <div class="flex-1 text-left">{{ appointmentDetail.patientCondition }}</div>
                </div>
                <div class="flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Chi tiết quá trình:</label>
                    <div class="flex-1 text-left">{{ appointmentDetail.treatmentProvided }}</div>
                </div>
                <div class="flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Lưu ý:</label>
                    <div class="flex-1 text-left">{{ appointmentDetail.notes }}</div>
                </div>
                <div class="flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Ngày đề xuất buổi
                        hẹn:</label>
                    <div class="flex-1 text-left">{{ formatDate(appointmentDetail.nextAppointmentDate) }}</div>
                </div>
            </div>
            <div v-if="appointment.appointmentReviewDto">
                <div class="flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Đánh giá cuộc hẹn:</label>
                    <div class="flex-1 text-left flex items-center">
                        <template v-if="review.appointmentRating">
                            <template v-for="star in 5" :key="star">
                                <svg :class="star <= review.appointmentRating ? 'w-4 h-4 text-yellow-300' : 'w-4 h-4 text-gray-300 dark:text-gray-500'"
                                    aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor"
                                    viewBox="0 0 22 20">
                                    <path
                                        d="M20.924 7.625a1.523 1.523 0 0 0-1.238-1.044l-5.051-.734-2.259-4.577a1.534 1.534 0 0 0-2.752 0L7.365 5.847l-5.051.734A1.535 1.535 0 0 0 1.463 9.2l3.656 3.563-.863 5.031a1.532 1.532 0 0 0 2.226 1.616L11 17.033l4.518 2.375a1.534 1.534 0 0 0 2.226-1.617l-.863-5.03L20.537 9.2a1.523 1.523 0 0 0 .387-1.575Z" />
                                </svg>
                            </template>
                        </template>
                    </div>
                </div>

                <div class="flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Nhận xét cuộc hẹn:</label>
                    <div class="flex-1 text-left">{{ review.appointmentComment }}</div>
                </div>
                <div class="flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Đánh giá nhân viên:</label>
                    <div class="flex-1 text-left flex items-center">
                        <template v-if="review.staffRating">
                            <template v-for="star in 5" :key="star">
                                <svg :class="star <= review.staffRating ? 'w-4 h-4 text-yellow-300' : 'w-4 h-4 text-gray-300 dark:text-gray-500'"
                                    aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor"
                                    viewBox="0 0 22 20">
                                    <path
                                        d="M20.924 7.625a1.523 1.523 0 0 0-1.238-1.044l-5.051-.734-2.259-4.577a1.534 1.534 0 0 0-2.752 0L7.365 5.847l-5.051.734A1.535 1.535 0 0 0 1.463 9.2l3.656 3.563-.863 5.031a1.532 1.532 0 0 0 2.226 1.616L11 17.033l4.518 2.375a1.534 1.534 0 0 0 2.226-1.617l-.863-5.03L20.537 9.2a1.523 1.523 0 0 0 .387-1.575Z" />
                                </svg>
                            </template>
                        </template>
                    </div>
                </div>
                <div class="flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Nhận xét về nhân
                        viên:</label>
                    <div class="flex-1 text-left">{{ review.staffComment }}</div>
                </div>
                <div class="flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Ngày đánh giá:</label>
                    <div class="flex-1 text-left">{{ formatDate(review.reviewDate) }}</div>
                </div>
            </div>
        </div>

        <router-link to="/review" class="font-medium text-blue-600 dark:text-blue-500 hover:underline">
            Quản lý đánh giá</router-link>
    </div>
</template>