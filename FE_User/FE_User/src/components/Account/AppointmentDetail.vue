<template>
    <Spinner v-if="isHandle" />
    <div class="relative m-4 p-4 overflow-x-auto shadow-md sm:rounded-lg">
        <h3 class="text-2xl font-extrabold dark:text-white">Chi tiết lịch hẹn</h3>
        <br />
        <div class="grid mb-2 gap-4">
            <div class="col-span-2 flex items-center">
                <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Khách hàng:</label>
                <div class="flex-1 text-left">{{ appointment.patientFullName }}</div>
            </div>
            <div class="col-span-2 flex items-center">
                <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Dịch vụ:</label>
                <div class="flex-1 text-left">{{appointment.servicePackageName}}</div>
            </div>
            <div class="col-span-2 flex items-center">
                <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Ngày hẹn:</label>
                <div class="flex-1 text-left">{{appointment.appointmentDate}}</div>
            </div>
            <div class="col-span-2 flex items-center">
                <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Thời gian:</label>
                <div class="flex-1 text-left">{{appointment.servicePackageName}}</div>
            </div>
            <div class="col-span-2 flex items-center">
                <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Địa chỉ:</label>
                <div class="flex-1 text-left">{{appointment.address}}</div>
            </div>
            <div class="col-span-2 flex items-center">
                <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Số điện thoại:</label>
                <div class="flex-1 text-left">{{appointment.phone}}</div>
            </div>
            <div class="col-span-2 flex items-center">
                <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Ghi chú:</label>
                <div class="flex-1 text-left">{{appointment.note}}</div>
            </div>
            <div class="col-span-2 flex items-center">
                <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Trạng thái:</label>
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
            <div class="col-span-2 flex items-center">
                <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Nhân viên:</label>
                <div class="flex-1 text-left">{{appointment?.staffFullName || 'Chưa sắp xếp'}}</div>
            </div>
        </div>
        <button v-if="btnEnable" type="button" @click="openCancelModal"
            class="mr-3 focus:outline-none text-white bg-red-600 hover:bg-red-800 focus:ring-4 focus:ring-red-300 font-medium rounded-lg text-sm px-5 py-2.5 me-2 mb-2 dark:bg-red-600 dark:hover:bg-red-700 dark:focus:ring-red-900">
            Hủy lịch hẹn
        </button>
        <router-link :to="`/subscription/${appointment.subscriptionId}`"
            class="font-medium text-blue-600 dark:text-blue-500 hover:underline">Quay
            lại</router-link>
        <div v-if="showDetail">
            <h3 class="py-2 text-xl font-extrabold dark:text-white">Chi tiết buổi hẹn</h3>
            <dl class="text-gray-900 dark:text-white grid gap-4 mt-2">
                <div class="flex flex-row">
                    <dt class="text-gray-500 dark:text-gray-400 font-semibold" style="min-width: 200px;">
                        Tình trạng bệnh nhân
                    </dt>
                    <dd class="text-sm">{{ appointmentDetail.patientCondition }}</dd>
                </div>
                <div class="flex flex-row">
                    <dt class="text-gray-500 dark:text-gray-400 font-semibold" style="min-width: 200px;">
                        Chi tiết quá trình
                    </dt>
                    <dd class="text-sm">{{ appointmentDetail.treatmentProvided }}</dd>
                </div>
                <div class="flex flex-row">
                    <dt class="text-gray-500 dark:text-gray-400 font-semibold" style="min-width: 200px;">
                        Lưu ý
                    </dt>
                    <dd class="text-sm">
                        {{ appointmentDetail.notes }}
                    </dd>
                </div>
                <div class="flex flex-row">
                    <dt class="text-gray-500 dark:text-gray-400 font-semibold" style="min-width: 200px;">
                        Ngày đề xuất buổi hẹn
                    </dt>
                    <dd class="text-sm">
                        {{ formatDate(appointmentDetail.nextAppointmentDate) }}
                    </dd>
                </div>
            </dl>
        </div>
        <BottomNav />
    </div>
    <div v-show="isModalCancelVisible" tabindex="-1" aria-hidden="true" @click.self="closeCancelModal"
        class="fixed inset-0 z-50 flex justify-center items-center w-full h-full bg-black bg-opacity-50">
        <div class="relative p-4 w-full max-w-xl max-h-full">
            <div class="relative bg-white rounded-lg shadow dark:bg-gray-700">
                <div class="flex items-center justify-between p-4 md:p-5 border-b rounded-t dark:border-gray-600">
                    <h3 class="text-xl font-semibold text-gray-900 dark:text-white">
                        Xác nhận hủy
                    </h3>
                </div>
                <div class="p-4 md:p-5 space-y-4">
                    <p class="text-base leading-relaxed text-gray-500 dark:text-gray-400">
                        Xác nhận hủy lịch hẹn?
                    </p>
                </div>
                <div
                    class="flex items-center justify-end p-4 md:p-5 border-t border-gray-200 rounded-b dark:border-gray-600">
                    <button type="button" @click="cancelAppointment"
                        class="text-white bg-red-600 hover:bg-red-800 focus:ring-4 focus:outline-none focus:ring-red-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-red-600 dark:hover:bg-red-700 dark:focus:ring-red-900">
                        Xác nhận
                    </button>
                    <button type="button" @click="closeCancelModal"
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
import BottomNav from './BottomNav.vue';

export default {
    name: 'AppointmentDetail',
    components: {
        BottomNav,
        Spinner
    },
    data() {
        return {
            appointment: {
                subscriptionId: '',
                patientFullName: '',
                staffFullName: '',
                servicePackageName: '',
                appointmentDate: '',
                status: '',
                address: '',
                phone: '',
                note: ''
            },
            appointmentId: '',
            btnEnable: false,
            isModalCancelVisible: false,
            showAppointmentDetail: false,
            appointmentDetail: {
                appointmentId: '',
                patientCondition: '',
                treatmentProvided: '',
                notes: '',
                nextAppointmentDate: '',
            },
            showDetail: false,
            isHandle: false,
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
                        this.showDetail = true;
                    }
                    if (this.appointment.status == "Scheduled" || this.appointment.status == "Pending") {
                        this.btnEnable = true;
                    }
                } else {
                    alert('Failed to load subscription data.');
                    this.$router.push(`/subscription/${this.appointment.subscriptionId}`);
                }
            } catch (error) {
                alert('An error occurred. Please try again.');
                this.$router.push(`/subscription/${this.appointment.subscriptionId}`);
            }
        },
        async cancelAppointment() {
            try {
                this.isHandle = true;
                const response = await fetch(`https://localhost:7072/api/appointment/${this.appointmentId}`, {
                    method: 'DELETE',
                    headers: {
                        'Content-Type': 'application/json',
                    }
                });

                if (response.ok) {
                    alert('Appointment cancel successfully!');
                    this.$router.push(`/subscription/${this.appointment.subscriptionId}`);
                } else {
                    this.isHandle = false;
                    alert('Failed to cancel.');
                }
            } catch (error) {
                console.error('Error:', error);
                alert('An error occurred. Please try again.');
            }
        },

        openCancelModal() {
            this.isModalCancelVisible = true;
        },

        closeCancelModal() {
            this.isModalCancelVisible = false;
        },

        formatDate(dateString) {
            const date = new Date(dateString);
            return date.toLocaleDateString('vi-VN', { day: '2-digit', month: '2-digit', year: 'numeric' });
        }
    },
}
</script>