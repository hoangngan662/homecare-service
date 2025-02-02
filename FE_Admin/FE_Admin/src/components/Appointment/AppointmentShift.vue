<script>
import axios from 'axios';

export default {
    name: 'AppointmentShift',
    data() {
        return {
            weeklyAppointments: [],
            loading: true,
            error: null,
            startDate: new Date().toISOString().split('T')[0], // Default to today's date
            shifts: [
                { "id": 1, "name": "7:30 - 9:30" },
                { "id": 2, "name": "10:00 - 12:00" },
                { "id": 3, "name": "13:00 - 15:00" },
                { "id": 4, "name": "15:30 - 17:30" },
                { "id": 5, "name": "18:00 - 20:00" }
            ],
            isShowDetail: false,
            selectedAppointment: null,
            staffs: [],
            showAppointmentDetail: false,
            appointmentDetail: {
                appointmentId: '',
                patientCondition: '',
                treatmentProvided: '',
                notes: '',
                nextAppointmentDate: '',
            },
            showDetail: false,
            filters: {
                pending: true,
                scheduled: true,
                completed: true,
                cancelled: true,
            },
        };
    },
    methods: {
        async fetchAppointments() {
            // Fetch appointments based on the selected start date
            try {
                this.loading = true;
                const response = await axios.get('https://localhost:7072/api/appointment/weekly', {
                    params: { startDate: this.startDate },
                });
                this.weeklyAppointments = response.data;
            } catch (err) {
                this.error = 'Failed to load appointments';
                console.error(err);
            } finally {
                this.loading = false;
            }
        },
        async openCrudModal(appointment) {
            this.selectedAppointment = appointment;
            this.isShowDetail = true;

            try {
                const res1 = await axios.get('https://localhost:7072/api/user/shift', {
                    params: {
                        shiftId: appointment.shiftId,
                        shiftDate: appointment.appointmentDate,
                    }
                });
                this.staffs = res1.data;

                if(appointment.appointmentDetailDto){
                    this.appointmentDetail = appointment.appointmentDetailDto;
                    this.showDetail = true;
                }
            } catch (err) {
                console.error('Failed to load available staff:', err);
                this.error = 'Could not load available staff';
            }
        },
        closeCrudModal() {
            this.isShowDetail = false;
            this.selectedAppointment = null;
            this.staffs = [];
            this.showDetail = false;
            this.appointmentDetail.appointmentId = '';
            this.appointmentDetail.patientCondition = '';
            this.appointmentDetail.treatmentProvided = '';
            this.appointmentDetail.notes = '';
            this.appointmentDetail.nextAppointmentDate = '';
        },
        async confirmAppointment() {
            if (!this.selectedAppointment.staffId) {
                alert('Vui lòng chọn nhân viên trước khi xác nhận lịch hẹn.');
                return;
            }

            try {
                const response = await axios.put(`https://localhost:7072/api/appointment/confirm`, null, {
                    params: {
                        id: this.selectedAppointment.id,
                        staffId: this.selectedAppointment.staffId,
                    }
                });
                alert('Lịch hẹn đã được xác nhận thành công!');
                this.closeCrudModal();
                location.reload();
            } catch (err) {
                console.error('Failed to confirm appointment:', err);
                alert('Đã có lỗi xảy ra trong quá trình xác nhận lịch hẹn.');
            }
        },
        async cancelAppointment() {
            try {
                this.isHandle = true;
                const response = await fetch(`https://localhost:7072/api/appointment/${this.selectedAppointment.id}`, {
                    method: 'DELETE',
                    headers: {
                        'Content-Type': 'application/json',
                    }
                });

                if (response.ok) {
                    alert('Hủy lịch hẹn thành công!');
                    location.reload();
                } else {
                    this.isHandle = false;
                    alert('Có lỗi xảy ra. Hãy thử lại.');
                }
            } catch (error) {
                console.error('Error:', error);
                alert('Có lỗi xảy ra. Hãy thử lại.');
            }
        },
        openDetailModal() {
            this.showAppointmentDetail = true;
        },
        closeDetailModal() {
            this.showAppointmentDetail = false;
        },
        async completeAppointment() {
            try {
                this.appointmentDetail.appointmentId = this.selectedAppointment.id;
                const response = await fetch(`https://localhost:7072/api/appointment/complete`, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(this.appointmentDetail),
                });

                if (response.ok) {
                    alert('Hoàn thành lịch hẹn!');
                    location.reload();
                } else {
                    this.isHandle = false;
                    alert('Có lỗi xảy ra. Hãy thử lại.');
                }
            } catch (error) {
                console.error('Error:', error);
                alert('Có lỗi xảy ra. Hãy thử lại.');
            }
        },
        formatDate(dateString) {
            const date = new Date(dateString);
            return date.toLocaleDateString('vi-VN', { day: '2-digit', month: '2-digit', year: 'numeric' });
        },
        filteredAppointments(appointments) {
            return appointments.filter(appointment => {
                return (
                    (this.filters.pending && appointment.status === 'Pending') ||
                    (this.filters.scheduled && appointment.status === 'Scheduled') ||
                    (this.filters.completed && appointment.status === 'Completed') ||
                    (this.filters.cancelled && appointment.status === 'Cancelled')
                );
            });
        },
    },
    async mounted() {
        await this.fetchAppointments();
    },
};
</script>

<template>
    <div class="relative p-4 overflow-x-auto shadow-md sm:rounded-lg">
        <h3 class="text-2xl font-extrabold dark:text-white">Danh sách lịch hẹn trong tuần</h3>
        <p class="my-4 text-sm text-gray-500">Danh sách các lịch hẹn theo ca làm việc trong tuần.</p>

        <div v-if="loading" class="text-gray-700 dark:text-gray-300">Loading...</div>
        <div v-else-if="error" class="text-red-500">{{ error }}</div>
        <div v-else>
            <div class="flex justify-between items-center mb-2">
                <div class="flex">
                    <div class="flex items-center me-4">
                        <input v-model="filters.pending" id="inline-checkbox" type="checkbox"
                            class="w-4 h-4 text-yellow-400 bg-gray-100 border-gray-300 rounded focus:ring-yellow-500 dark:focus:ring-yellow-600 dark:ring-offset-gray-800 focus:ring-2 dark:bg-gray-700 dark:border-gray-600">
                        <label for="inline-checkbox"
                            class="ms-2 text-sm font-medium text-gray-900 dark:text-gray-300">Chờ xử lý</label>
                    </div>
                    <div class="flex items-center me-4">
                        <input v-model="filters.scheduled" id="inline-2-checkbox" type="checkbox"
                            class="w-4 h-4 text-green-600 bg-gray-100 border-gray-300 rounded focus:ring-green-500 dark:focus:ring-green-600 dark:ring-offset-gray-800 focus:ring-2 dark:bg-gray-700 dark:border-gray-600">
                        <label for="inline-2-checkbox"
                            class="ms-2 text-sm font-medium text-gray-900 dark:text-gray-300">Đã lên lịch</label>
                    </div>
                    <div class="flex items-center me-4">
                        <input v-model="filters.completed" id="inline-checked-checkbox" type="checkbox"
                            class="w-4 h-4 text-blue-600 bg-gray-100 border-gray-300 rounded focus:ring-blue-500 dark:focus:ring-blue-600 dark:ring-offset-gray-800 focus:ring-2 dark:bg-gray-700 dark:border-gray-600">
                        <label for="inline-checked-checkbox"
                            class="ms-2 text-sm font-medium text-gray-900 dark:text-gray-300">Hoàn thành</label>
                    </div>
                    <div class="flex items-center">
                        <input v-model="filters.cancelled" id="inline-disabled-checkbox" type="checkbox"
                            class="w-4 h-4 text-red-600 bg-gray-100 border-gray-300 rounded focus:ring-red-500 dark:focus:ring-red-600 dark:ring-offset-gray-800 focus:ring-2 dark:bg-gray-700 dark:border-gray-600">
                        <label for="inline-disabled-checkbox"
                            class="ms-2 text-sm font-medium text-gray-900 dark:text-gray-300">Hủy</label>
                    </div>
                </div>
                <div class="flex items-center">
                    <label for="startDate" class="mr-2 text-sm font-medium text-gray-900 dark:text-gray-300">Chọn
                        ngày:</label>
                    <input type="date" v-model="startDate" @change="fetchAppointments" id="startDate"
                        class="p-2 border border-gray-300 rounded focus:ring-2 focus:ring-blue-500 dark:bg-gray-700 dark:border-gray-600 dark:text-gray-300" />
                </div>
            </div>

            <table
                class="w-full text-sm text-center text-gray-500 dark:text-gray-400 border-collapse border border-gray-200 dark:border-gray-700">
                <thead class="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
                    <tr class="font-medium">
                        <th class="w-24 px-6 py-3 border border-gray-200 dark:border-gray-700">Ca</th>
                        <th v-for="day in weeklyAppointments" :key="day.date"
                            class="w-32 px-6 py-3 border border-gray-200 dark:border-gray-700">
                            {{ new Date(day.date).toLocaleDateString('en-GB') }}
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="shift in shifts" :key="shift.id"
                        class="border border-gray-200 dark:border-gray-700 hover:bg-blue-50 dark:hover:bg-gray-600">
                        <td
                            class="px-2 py-4 font-medium text-gray-900 dark:text-white border border-gray-200 dark:border-gray-700 whitespace-nowrap">
                            Ca {{ shift.id }}
                            <br />
                            {{ shift.name }}
                        </td>
                        <td v-for="day in weeklyAppointments" :key="day.date"
                            class="w-32 p-2 border border-gray-200 dark:border-gray-700 break-words">
                            <div v-if="day.shifts.find(s => s.shiftId === shift.id)">
                                <div v-for="appointment in filteredAppointments(day.shifts.find(s => s.shiftId === shift.id).appointments)"
                                    :key="appointment.id" :class="{
                            'bg-green-100 text-green-800': appointment.status === 'Scheduled',
                            'bg-yellow-100 text-yellow-800': appointment.status === 'Pending',
                            'bg-blue-100 text-blue-800': appointment.status === 'Completed',
                            'bg-red-100 text-red-800': appointment.status === 'Cancelled'
                        }" class="mb-2 p-2 rounded border-gray-300 dark:border-gray-600 cursor-pointer break-words"
                                    @click="openCrudModal(appointment)">
                                    <p class="font-semibold text-xs">
                                        Nhân viên: {{ appointment.staffFullName || 'Chưa sắp xếp' }}
                                    </p>
                                    <p class="font-semibold text-xs">Khách hàng: {{ appointment.patientFullName }}</p>
                                    <p class="text-xs">{{ appointment.serviceTypeName }}</p>
                                    <p class="text-xs">SĐT: {{ appointment.phone }}</p>
                                    <p class="text-xs">Địa chỉ: {{ appointment.address }}</p>
                                    <div v-if="appointment.status === 'Completed'"
                                        class="flex justify-center items-center">
                                        <template v-if="appointment.appointmentReviewDto?.appointmentRating">
                                            <template v-for="star in 5" :key="star">
                                                <svg :class="star <= appointment.appointmentReviewDto.appointmentRating ? 'w-4 h-4 text-yellow-300' : 'w-4 h-4 text-gray-300 dark:text-gray-500'"
                                                    aria-hidden="true" xmlns="http://www.w3.org/2000/svg"
                                                    fill="currentColor" viewBox="0 0 22 20">
                                                    <path
                                                        d="M20.924 7.625a1.523 1.523 0 0 0-1.238-1.044l-5.051-.734-2.259-4.577a1.534 1.534 0 0 0-2.752 0L7.365 5.847l-5.051.734A1.535 1.535 0 0 0 1.463 9.2l3.656 3.563-.863 5.031a1.532 1.532 0 0 0 2.226 1.616L11 17.033l4.518 2.375a1.534 1.534 0 0 0 2.226-1.617l-.863-5.03L20.537 9.2a1.523 1.523 0 0 0 .387-1.575Z" />
                                                </svg>
                                            </template>
                                        </template>
                                        <template v-else>
                                            <span class="text-gray-500">Chưa đánh giá</span>
                                        </template>
                                    </div>
                                </div>
                            </div>
                            <div v-else class="text-gray-400 italic">Không có lịch hẹn</div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>

        <!-- Modal for appointment details -->
        <div v-show="isShowDetail" tabindex="-1" aria-hidden="true" @click.self="closeCrudModal"
            class="fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-50">
            <div class="relative p-4 w-full max-w-xl bg-white rounded-lg shadow dark:bg-gray-700">
                <div class="flex items-center justify-between p-4 md:p-2 border-b rounded-t dark:border-gray-600">
                    <h3 class="text-lg font-semibold text-gray-900 dark:text-white">
                        Thông tin lịch hẹn
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
                <div class="grid gap-2 mb-2 grid-cols-2 mt-2">
                    <div class="flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Khách hàng:</label>
                        <!-- <div class="flex-1 text-left">{{ selectedAppointment?.patientFullName }}</div> -->
                        <a class="flex-1 text-left hover:underline font-bold"
                            :href="`/patient/${selectedAppointment?.patientId}`">
                            {{ selectedAppointment?.patientFullName }}
                        </a>
                    </div>
                    <div class="flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Dịch vụ:</label>
                        <div class="flex-1 text-left">{{ selectedAppointment?.serviceTypeName }} - {{
                            selectedAppointment?.servicePackageName }}</div>
                    </div>
                    <div class="flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Ngày hẹn:</label>
                        <div class="flex-1 text-left">{{ formatDate(selectedAppointment?.appointmentDate) }}</div>
                    </div>
                    <div class="flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Thời gian:</label>
                        <div class="flex-1 text-left">{{ selectedAppointment?.shiftTime }}</div>
                    </div>
                    <div class="flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Địa chỉ:</label>
                        <div class="flex-1 text-left">{{ selectedAppointment?.address }}</div>
                    </div>
                    <div class="flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Số điện thoại:</label>
                        <div class="flex-1 text-left">{{ selectedAppointment?.phone }}</div>
                    </div>
                    <div class="flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Trạng thái:</label>
                        <div class="flex-1 text-left">
                            <span v-if="selectedAppointment?.status === 'Pending'"
                                class="bg-yellow-100 text-yellow-800 text-xs font-medium px-2.5 py-0.5 rounded-full dark:bg-yellow-900 dark:text-yellow-300">
                                Chờ xử lý
                            </span>
                            <span v-else-if="selectedAppointment?.status === 'Scheduled'"
                                class="bg-green-100 text-green-800 text-xs font-medium px-2.5 py-0.5 rounded-full dark:bg-green-900 dark:text-green-300">
                                Đã lên lịch
                            </span>
                            <span v-else-if="selectedAppointment?.status === 'Completed'"
                                class="bg-blue-100 text-blue-800 text-xs font-medium px-2.5 py-0.5 rounded-full dark:bg-blue-900 dark:text-blue-300">
                                Hoàn thành
                            </span>
                            <span v-else-if="selectedAppointment?.status === 'Cancelled'"
                                class="bg-red-100 text-red-800 text-xs font-medium px-2.5 py-0.5 rounded-full dark:bg-red-900 dark:text-red-300">
                                Hủy
                            </span>
                            <span v-else
                                class="bg-gray-100 text-gray-800 text-xs font-medium px-2.5 py-0.5 rounded-full dark:bg-gray-900 dark:text-gray-300">
                                Default
                            </span>
                        </div>
                    </div>
                    <div class="flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Ghi chú:</label>
                        <div class="flex-1 text-left">{{ selectedAppointment?.note || 'Không có ghi chú' }}</div>
                    </div>
                    <div class="flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Nhân viên:</label>
                        <template v-if="selectedAppointment?.status !== 'Pending'">
                            <div class="flex-1 text-left">
                                {{ selectedAppointment?.staffFullName }}
                            </div>
                        </template>
                        <template v-else>
                            <select v-if="staffs.length > 0" v-model="selectedAppointment.staffId" required
                                class="border rounded p-1 flex-1 text-left ml-20">
                                <option value="" disabled selected>Chọn nhân viên</option>
                                <option v-for="staff in staffs" :key="staff.id" :value="staff.id">
                                    {{ staff.fullname }} - {{ staff.specialization }}
                                </option>
                            </select>
                        </template>
                    </div>
                </div>

                <!-- <div class="grid grid-cols-2 gap-4 mt-2">
                    <div v-if="showDetail" class="flex flex-col">
                        <div class="flex items-center mb-2">
                            <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Tình trạng:</label>
                            <div class="flex-1 text-left">{{ appointmentDetail.patientCondition }}</div>
                        </div>
                        <div class="flex items-center mb-2">
                            <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Quá trình:</label>
                            <div class="flex-1 text-left">{{ appointmentDetail.treatmentProvided }}</div>
                        </div>
                        <div class="flex items-center mb-2">
                            <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Lưu ý:</label>
                            <div class="flex-1 text-left">{{ appointmentDetail.notes }}</div>
                        </div>
                        <div class="flex items-center mb-2">
                            <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Ngày đề xuất:</label>
                            <div class="flex-1 text-left">{{ formatDate(appointmentDetail.nextAppointmentDate) }}</div>
                        </div>
                    </div>

                    <div v-if="selectedAppointment?.appointmentReviewDto" class="flex flex-col">
                        <div class="flex items-center mb-2">
                            <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Đánh giá buổi
                                hẹn:</label>
                            <div class="flex-1 text-left">
                                <template v-if="selectedAppointment.appointmentReviewDto.appointmentRating">
                                    <div class="flex items-center">
                                        <template v-for="star in 5" :key="star">
                                            <svg :class="star <= selectedAppointment.appointmentReviewDto.appointmentRating ? 'w-4 h-4 text-yellow-300' : 'w-4 h-4 text-gray-300 dark:text-gray-500'"
                                                aria-hidden="true" xmlns="http://www.w3.org/2000/svg"
                                                fill="currentColor" viewBox="0 0 22 20">
                                                <path
                                                    d="M20.924 7.625a1.523 1.523 0 0 0-1.238-1.044l-5.051-.734-2.259-4.577a1.534 1.534 0 0 0-2.752 0L7.365 5.847l-5.051.734A1.535 1.535 0 0 0 1.463 9.2l3.656 3.563-.863 5.031a1.532 1.532 0 0 0 2.226 1.616L11 17.033l4.518 2.375a1.534 1.534 0 0 0 2.226-1.617l-.863-5.03L20.537 9.2a1.523 1.523 0 0 0 .387-1.575Z" />
                                            </svg>
                                        </template>
                                    </div>
                                </template>
                                <template v-else>
                                    <span class="text-gray-500">Chưa có đánh giá</span>
                                </template>
                            </div>
                        </div>
                        <div class="flex items-center">
                            <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Đánh giá nhân
                                viên:</label>
                            <div class="flex-1 text-left">
                                <template v-if="selectedAppointment.appointmentReviewDto.staffRating">
                                    <div class="flex items-center">
                                        <template v-for="star in 5" :key="star">
                                            <svg :class="star <= selectedAppointment.appointmentReviewDto.staffRating ? 'w-4 h-4 text-yellow-300' : 'w-4 h-4 text-gray-300 dark:text-gray-500'"
                                                aria-hidden="true" xmlns="http://www.w3.org/2000/svg"
                                                fill="currentColor" viewBox="0 0 22 20">
                                                <path
                                                    d="M20.924 7.625a1.523 1.523 0 0 0-1.238-1.044l-5.051-.734-2.259-4.577a1.534 1.534 0 0 0-2.752 0L7.365 5.847l-5.051.734A1.535 1.535 0 0 0 1.463 9.2l3.656 3.563-.863 5.031a1.532 1.532 0 0 0 2.226 1.616L11 17.033l4.518 2.375a1.534 1.534 0 0 0 2.226-1.617l-.863-5.03L20.537 9.2a1.523 1.523 0 0 0 .387-1.575Z" />
                                            </svg>
                                        </template>
                                    </div>
                                </template>
                                <template v-else>
                                    <span class="text-gray-500">Chưa có đánh giá</span>
                                </template>
                            </div>
                        </div>
                        <div class="flex items-center mb-2">
                            <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Nhận xét buổi
                                hẹn:</label>
                            <div class="flex-1 text-left">
                                <span>
                                    {{ selectedAppointment.appointmentReviewDto.appointmentComment || 'Không có nhận xét' }}
                                </span>
                            </div>
                        </div>
                        <div class="flex items-center mb-2">
                            <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Nhận xét nhân
                                viên:</label>
                            <div class="flex-1 text-left">
                                <span>
                                    {{ selectedAppointment.appointmentReviewDto.staffComment || 'Không có nhận xét' }}
                                </span>
                            </div>
                        </div>
                    </div>
                </div> -->
                <router-link :to="`/appointment/${selectedAppointment?.id}`" type="button"
                    class="mr-3 text-white inline-flex items-center bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">
                    Chi tiết
                </router-link>
                <button type="button" @click="confirmAppointment" v-if="selectedAppointment?.status === 'Pending'"
                    class="mr-3 text-white inline-flex items-center bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">
                    Xác nhận
                </button>
                <button type="button" @click="openDetailModal" v-if="selectedAppointment?.status === 'Scheduled'"
                    class="mr-3 text-white inline-flex items-center bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">
                    Hoàn thành
                </button>
                <button type="button" @click="cancelAppointment"
                    v-if="selectedAppointment?.status === 'Pending' || selectedAppointment?.status === 'Scheduled'"
                    class="mr-3 focus:outline-none text-white bg-red-600 hover:bg-red-800 focus:ring-4 focus:ring-red-300 font-medium rounded-lg text-sm px-5 py-2.5 me-2 mb-2 dark:bg-red-600 dark:hover:bg-red-700 dark:focus:ring-red-900">
                    Hủy lịch hẹn
                </button>
            </div>
        </div>

        <div v-show="showAppointmentDetail" tabindex="-1" aria-hidden="true" @click.self="closeDetailModal"
            class="fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-50">
            <div class="relative p-4 w-full max-w-md max-h-full bg-white rounded-lg shadow dark:bg-gray-700">
                <div class="flex items-center justify-between p-4 md:p-2 border-b rounded-t dark:border-gray-600">
                    <h3 class="text-lg font-semibold text-gray-900 dark:text-white">
                        Chi tiết buổi hẹn
                    </h3>
                    <button type="button" @click="closeDetailModal"
                        class="text-gray-400 bg-transparent hover:bg-gray-200 hover:text-gray-900 rounded-lg text-sm w-8 h-8 inline-flex justify-center items-center dark:hover:bg-gray-600 dark:hover:text-white">
                        <svg class="w-3 h-3" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none"
                            viewBox="0 0 14 14">
                            <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                d="m1 1 6 6m0 0 6 6M7 7l6-6M7 7l-6 6" />
                        </svg>
                        <span class="sr-only">Close modal</span>
                    </button>
                </div>
                <form class="p-4 md:p-2" @submit.prevent="completeAppointment">
                    <div class="grid gap-4 mb-2 grid-cols-2">
                        <div class="col-span-2">
                            <label class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Tình trạng bệnh
                                nhân
                                <span class="text-red-600 text-sm">*</span>
                            </label>
                            <textarea type="text" v-model="appointmentDetail.patientCondition"
                                class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                                placeholder="nhiệt độ cơ thể..." required></textarea>
                        </div>
                        <div class="col-span-2">
                            <label class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Chi tiết chăm
                                sóc
                                <span class="text-red-600 text-sm">*</span>
                            </label>
                            <textarea type="text" v-model="appointmentDetail.treatmentProvided"
                                class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                                placeholder="Thay băng vết mổ..." required></textarea>
                        </div>
                        <div class="col-span-2">
                            <label class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Ghi chú</label>
                            <textarea type="text" v-model="appointmentDetail.notes"
                                class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                                placeholder="Ghi chú"></textarea>
                        </div>
                        <div class="col-span-2">
                            <label class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">
                                Ngày hẹn đề xuất
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
                                <input datepicker-autohide type="date" v-model="appointmentDetail.nextAppointmentDate"
                                    class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full ps-10 p-2.5  dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                                    placeholder="Chọn ngày bắt đầu" required>
                            </div>
                        </div>
                    </div>
                    <button type="submit"
                        class="text-white inline-flex items-center bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">
                        Xác nhận
                    </button>
                </form>
            </div>
        </div>
    </div>
</template>
