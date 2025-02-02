<template>
    <Spinner v-if="isHandle" />
    <Toast v-if="isSuccessVisible" :message="successMessage" :isVisible="isSuccessVisible" @close="hideSuccessToast" />
    <Toast v-if="isErrorVisible" :message="errorMessage" :isVisible="isErrorVisible" @close="hideErrorToast" />

    <div class="relative m-4 p-4 overflow-x-auto shadow-md sm:rounded-lg">
        <div class="grid md:grid-cols-2 gap-4">
            <!-- Subscription Details Section -->
            <div>
                <h3 class="text-2xl font-extrabold dark:text-white">Chi tiết đăng ký dịch vụ</h3>
                <br />
                <div class="grid mb-2 gap-4">
                    <div class="col-span-2 flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Khách hàng:</label>
                        <div class="flex-1 text-left">{{ subscription.patientFullName }}</div>
                    </div>
                    <div class="col-span-2 flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Dịch vụ:</label>
                        <div class="flex-1 text-left">{{subscription.serviceTypeName}} -
                            {{subscription.servicePackageName}}</div>
                    </div>
                    <div class="col-span-2 flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Ngày đăng ký:</label>
                        <div class="flex-1 text-left">{{ subscription.subscriptionDate }}</div>
                    </div>
                    <div class="col-span-2 flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Thời hạn:</label>
                        <div class="flex-1 text-left">{{ subscription.startDate }} - {{ subscription.endDate }}</div>
                    </div>
                    <div class="col-span-2 flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Số tiền:</label>
                        <div class="flex-1 text-left">{{ formatPrice(subscription.total) }} VNĐ</div>
                    </div>
                    <div v-if="subscription.status !== 'Cancelled'" class="col-span-2 flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Thanh toán:</label>
                        <div class="flex-1 text-left">
                            <span v-if="subscription.isPaid">Đã thanh toán</span>
                            <span v-else>
                                <button v-if="btnPay" type="button" @click="payment"
                                    class="focus:outline-none text-white bg-blue-600 hover:bg-blue-800 focus:ring-4 focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-900">
                                    Thanh toán
                                </button>
                                <span class="ml-2 text-red-600 text-xs">* </span>
                                <span class="text-xs">Thanh toán để kích hoạt </span>
                            </span>
                        </div>
                    </div>
                    <div v-if="subscription.isPaid" class="col-span-2 flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Ngày thanh toán:</label>
                        <div class="flex-1 text-left">
                            {{ new Date(subscription.paymentDate).toLocaleDateString('en-GB') }}
                            {{ new Date(subscription.paymentDate).toLocaleTimeString([], { hour: '2-digit', minute:
                            '2-digit' }) }}
                        </div>
                    </div>
                    <div class="col-span-2 flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Trạng thái:</label>
                        <div class="flex-1 text-left">
                            <span v-if="subscription.status === 'Pending'"
                                class="bg-yellow-100 text-yellow-800 text-xs font-medium px-2.5 py-0.5 rounded-full dark:bg-yellow-900 dark:text-yellow-300">
                                Chưa kích hoạt
                            </span>
                            <span v-else-if="subscription.status === 'Active'"
                                class="bg-green-100 text-green-800 text-xs font-medium px-2.5 py-0.5 rounded-full dark:bg-green-900 dark:text-green-300">
                                Đã kích hoạt
                            </span>
                            <span v-else-if="subscription.status === 'Completed'"
                                class="bg-blue-100 text-blue-800 text-xs font-medium px-2.5 py-0.5 rounded-full dark:bg-blue-900 dark:text-blue-300">
                                Hoàn thành
                            </span>
                            <span v-else-if="subscription.status === 'Cancelled'"
                                class="bg-red-100 text-red-800 text-xs font-medium px-2.5 py-0.5 rounded-full dark:bg-red-900 dark:text-red-300">
                                Hủy
                            </span>
                            <span v-else
                                class="bg-gray-100 text-gray-800 text-xs font-medium px-2.5 py-0.5 rounded-full dark:bg-gray-900 dark:text-gray-300">
                                Default
                            </span>
                        </div>
                    </div>
                    <div v-if="subscription.isPaid" class="col-span-2 flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Đã sử dụng:</label>
                        <div class="flex-1 text-left">{{ subscription.usedSessions }}
                            buổi/{{subscription.servicePackageName}}</div>
                    </div>
                </div>
            </div>

            <!-- Appointments Table Section -->
            <div v-if="subscription.status === 'Active' || subscription.status === 'Completed'">
                <h3 class="mt-4 text-xl font-extrabold dark:text-white">Các buổi hẹn</h3>
                <br />
                <button v-if="btnAdd" type="button" @click="openCrudModal"
                    class="flex items-center w-fit text-gray-900 bg-white border border-gray-300 focus:outline-none hover:bg-gray-100 focus:ring-4 focus:ring-gray-100 font-medium rounded-full text-sm px-5 py-2.5 me-2 mb-2 dark:bg-gray-800 dark:text-white dark:border-gray-600 dark:hover:bg-gray-700 dark:hover:border-gray-600 dark:focus:ring-gray-700">
                    <svg class="w-6 h-6 text-gray-800 dark:text-white me-2" aria-hidden="true"
                        xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none" viewBox="0 0 24 24">
                        <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                            d="M5 12h14m-7 7V5" />
                    </svg>
                    Thêm
                </button>

                <table class="w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400">
                    <thead class="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
                        <tr>
                            <th scope="col" class="px-6 py-3">STT</th>
                            <th scope="col" class="px-6 py-3">Nhân viên</th>
                            <th scope="col" class="px-6 py-3">Ngày hẹn</th>
                            <th scope="col" class="px-6 py-3">Trạng thái</th>
                            <th scope="col" class="px-6 py-3">Xử lý</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="(app, index) in appointments" :key="app.id"
                            class="bg-white border-b dark:bg-gray-800 dark:border-gray-700 hover:bg-gray-50 dark:hover:bg-gray-600">
                            <td class="p-2">{{ ++index }}</td>
                            <td class="p-2">{{ app?.staffFullName || 'Chưa sắp xếp' }}</td>
                            <td class="p-2">
                                {{ new Date(app.appointmentDate).toLocaleDateString('en-GB') }}
                                <br />
                                {{ app.shiftTime }}
                            </td>
                            <td class="p-2">
                                <span v-if="app.status === 'Pending'"
                                    class="bg-yellow-100 text-yellow-800 text-xs font-medium me-2 px-2.5 py-0.5 rounded-full dark:bg-yellow-900 dark:text-yellow-300">
                                    Chờ xử lý
                                </span>
                                <span v-else-if="app.status === 'Scheduled'"
                                    class="bg-green-100 text-green-800 text-xs font-medium me-2 px-2.5 py-0.5 rounded-full dark:bg-green-900 dark:text-green-300">
                                    Đã lên lịch
                                </span>
                                <div v-else-if="app.status === 'Completed'">
                                    <span
                                        class="bg-blue-100 text-blue-800 text-xs font-medium me-2 px-2.5 py-0.5 rounded-full dark:bg-blue-900 dark:text-blue-300">
                                        Hoàn thành
                                    </span>
                                    <br />
                                    <div class="flex items-center">
                                        <template v-if="app.appointmentReviewDto?.appointmentRating">
                                            <template v-for="star in 5" :key="star">
                                                <svg :class="star <= app.appointmentReviewDto.appointmentRating ? 'w-4 h-4 text-yellow-300' : 'w-4 h-4 text-gray-300 dark:text-gray-500'"
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
                                <span v-else-if="app.status === 'Cancelled'"
                                    class="bg-red-100 text-red-800 text-xs font-medium me-2 px-2.5 py-0.5 rounded-full dark:bg-red-900 dark:text-red-300">
                                    Hủy
                                </span>
                                <span v-else
                                    class="bg-gray-100 text-gray-800 text-xs font-medium me-2 px-2.5 py-0.5 rounded-full dark:bg-gray-900 dark:text-gray-300">
                                    Default
                                </span>
                            </td>
                            <td class="p-2">
                                <!-- <a :href="`/appointment/${app.id}`"
                                    class="font-medium text-blue-600 dark:text-blue-500 hover:underline">Chi tiết</a> -->
                                <button @click="openDetailModal(app.id)"
                                    class="font-medium text-blue-600 dark:text-blue-500 hover:underline">Chi
                                    tiết</button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>

        <!-- Action Buttons Section -->
        <div class="flex items-center space-x-4">
            <button v-if="btnCancel" type="button" @click="openCancelModal"
                class="focus:outline-none text-white bg-red-600 hover:bg-red-800 focus:ring-4 focus:ring-red-300 font-medium rounded-lg text-sm px-5 py-2.5 dark:bg-red-600 dark:hover:bg-red-700 dark:focus:ring-red-900">
                Hủy gói
            </button>
            <router-link to="/subscription" class="font-medium text-blue-600 dark:text-blue-500 hover:underline">Quay
                lại</router-link>
        </div>

        <BottomNav />
    </div>
    <div v-show="isModalCreateVisible" tabindex="-1" aria-hidden="true" @click.self="closeCrudModal"
        class="fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-50">
        <div class="relative p-4 w-full max-w-md max-h-full bg-white rounded-lg shadow dark:bg-gray-700">
            <div class="flex items-center justify-between p-4 md:p-2 border-b rounded-t dark:border-gray-600">
                <h3 class="text-lg font-semibold text-gray-900 dark:text-white">
                    Thêm lịch hẹn
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
            <form class="p-4 md:p-2" @submit.prevent="addAppointment">
                <div class="grid gap-4 mb-2 grid-cols-2">
                    <!-- Column for selecting the appointment date -->
                    <div>
                        <label class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">
                            Ngày hẹn
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
                            <!-- <input datepicker-autohide type="date" v-model="appointment.appointmentDate"
                                class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full ps-10 p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                                placeholder="Chọn ngày bắt đầu" required> -->
                            <input datepicker-autohide type="date" v-model="appointment.appointmentDate"
                                class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full ps-10 p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                                placeholder="Chọn ngày bắt đầu" required :min="minDate">
                        </div>
                    </div>

                    <!-- Column for selecting the shift -->
                    <div>
                        <label class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">
                            Chọn giờ hẹn
                            <span class="text-red-600 text-sm">*</span>
                        </label>
                        <select v-model="appointment.shiftId"
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
                            <option disabled value="">Chọn giờ hẹn</option>
                            <option v-for="shift in shifts" :key="shift.id" :value="shift.id">
                                {{ shift.shiftTime }}
                            </option>
                        </select>
                    </div>
                    <div class="col-span-2">
                        <label class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Địa chỉ
                            <span class="text-red-600 text-sm">*</span>
                        </label>
                        <input type="text" v-model="appointment.address"
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                            placeholder="123 Ninh Kiều" required />
                    </div>
                    <div class="col-span-2">
                        <label class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Số điện
                            thoại
                            <span class="text-red-600 text-sm">*</span>
                        </label>
                        <input type="text" v-model="appointment.phone"
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                            placeholder="0123456789" required />
                    </div>
                    <div class="col-span-2">
                        <label class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Ghi chú</label>
                        <input type="text" v-model="appointment.note"
                            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                            placeholder="Ghi chú" />
                    </div>
                </div>
                <button type="submit"
                    class="text-white inline-flex items-center bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">
                    <svg class="me-1 -ms-1 w-5 h-5" fill="currentColor" viewBox="0 0 20 20"
                        xmlns="http://www.w3.org/2000/svg">
                        <path fill-rule="evenodd"
                            d="M10 5a1 1 0 011 1v3h3a1 1 0 110 2h-3v3a1 1 0 11-2 0v-3H6a1 1 0 110-2h3V6a1 1 0 011-1z"
                            clip-rule="evenodd"></path>
                    </svg>
                    Thêm
                </button>
            </form>
        </div>
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
                        Xác nhận hủy đăng ký dịch vụ?
                    </p>
                </div>
                <div
                    class="flex items-center justify-end p-4 md:p-5 border-t border-gray-200 rounded-b dark:border-gray-600">
                    <button type="button" @click="cancelSubscription"
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
    <div v-show="isShowDetail" tabindex="-1" aria-hidden="true" @click.self="closeDetailModal"
        class="fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-50">
        <div class="relative p-4 w-full max-w-xl bg-white rounded-lg shadow dark:bg-gray-700">
            <div class="flex items-center justify-between p-4 md:p-2 border-b rounded-t dark:border-gray-600">
                <h3 class="text-lg font-semibold text-gray-900 dark:text-white">
                    Chi tiết lịch hẹn
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
            <div class="grid gap-2 mb-2 p-2">
                <div class="col-span-2 flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Khách hàng:</label>
                    <div class="flex-1 text-left">{{ selectedAppointment?.patientFullName }}</div>
                </div>
                <div class="col-span-2 flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Dịch vụ:</label>
                    <div class="flex-1 text-left">{{ selectedAppointment?.serviceTypeName }} - {{
                        selectedAppointment?.servicePackageName }}</div>
                </div>
                <div class="col-span-2 flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Ngày hẹn:
                        <span class="text-red-600 text-sm">*</span>
                    </label>
                    <div class="flex-1 text-left">
                        <input v-if="selectedAppointment?.status === 'Pending'" type="date"
                            v-model="formattedAppointmentDate"
                            class="border rounded p-1 w-full bg-gray-50 border-gray-300 text-gray-900 text-sm focus:ring-blue-500 focus:border-blue-500 block dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                            required :min="minDate"/>
                        <span v-else>{{ formatDate(selectedAppointment?.appointmentDate) }}</span>
                    </div>
                </div>

                <div class="col-span-2 flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Thời gian:
                        <span class="text-red-600 text-sm">*</span>
                    </label>
                    <div class="flex-1 text-left">
                        <select v-if="selectedAppointment?.status === 'Pending'" v-model="selectedAppointment.shiftId"
                            class="border rounded p-1 w-full bg-gray-50 border-gray-300 text-gray-900 text-sm focus:ring-blue-500 focus:border-blue-500 block dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
                            <option v-for="shift in shifts" :key="shift.id" :value="shift.id">
                                {{ shift.shiftTime }}
                            </option>
                        </select>
                        <span v-else>{{ selectedAppointment?.shiftTime }}</span>
                    </div>
                </div>

                <div class="col-span-2 flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Địa chỉ:
                        <span class="text-red-600 text-sm">*</span>
                    </label>
                    <div class="flex-1 text-left">
                        <input v-if="selectedAppointment?.status === 'Pending'" v-model="selectedAppointment.address"
                            class="border rounded p-1 w-full bg-gray-50 border-gray-300 text-gray-900 text-sm focus:ring-blue-500 focus:border-blue-500 block dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                            required />
                        <span v-else>{{ selectedAppointment?.address }}</span>
                    </div>
                </div>

                <div class="col-span-2 flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Số điện thoại:
                        <span class="text-red-600 text-sm">*</span>
                    </label>
                    <div class="flex-1 text-left">
                        <input v-if="selectedAppointment?.status === 'Pending'" v-model="selectedAppointment.phone"
                            class="border rounded p-1 w-full bg-gray-50 border-gray-300 text-gray-900 text-sm focus:ring-blue-500 focus:border-blue-500 block dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                            required />
                        <span v-else>{{ selectedAppointment?.phone }}</span>
                    </div>
                </div>

                <div class="col-span-2 flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Ghi chú:</label>
                    <div class="flex-1 text-left">
                        <input v-if="selectedAppointment?.status === 'Pending'" v-model="selectedAppointment.note"
                            class="border rounded p-1 w-full bg-gray-50 border-gray-300 text-gray-900 text-sm focus:ring-blue-500 focus:border-blue-500 block dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" />
                        <span v-else>{{ selectedAppointment?.note || 'Không có ghi chú' }}</span>
                    </div>
                </div>

                <div class="col-span-2 flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Nhân viên:</label>
                    <div class="flex-1 text-left">
                        {{ selectedAppointment?.staffFullName || 'Chưa sắp xếp' }}
                    </div>
                </div>
                <div class="col-span-2 flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Trạng thái:</label>
                    <div class="flex-1 text-left">
                        <span v-if="selectedAppointment?.status === 'Pending'"
                            class="bg-yellow-100 text-yellow-800 text-xs font-medium me-2 px-2.5 py-0.5 rounded-full dark:bg-yellow-900 dark:text-yellow-300">
                            Chờ xử lý
                        </span>
                        <span v-else-if="selectedAppointment?.status === 'Scheduled'"
                            class="bg-green-100 text-green-800 text-xs font-medium me-2 px-2.5 py-0.5 rounded-full dark:bg-green-900 dark:text-green-300">
                            Đã lên lịch
                        </span>
                        <div v-else-if="selectedAppointment?.status === 'Completed'" class="flex items-center">
                            <span
                                class="bg-blue-100 text-blue-800 text-xs font-medium me-2 px-2.5 py-0.5 rounded-full dark:bg-blue-900 dark:text-blue-300">
                                Hoàn thành
                            </span>
                            <div class="flex items-center">
                                <template v-if="selectedAppointment?.appointmentReviewDto?.appointmentRating">
                                    <template v-for="star in 5" :key="star">
                                        <svg :class="star <= selectedAppointment.appointmentReviewDto.appointmentRating ? 'w-4 h-4 text-yellow-300' : 'w-4 h-4 text-gray-300 dark:text-gray-500'"
                                            aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor"
                                            viewBox="0 0 22 20">
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

                        <span v-else-if="selectedAppointment?.status === 'Cancelled'"
                            class="bg-red-100 text-red-800 text-xs font-medium me-2 px-2.5 py-0.5 rounded-full dark:bg-red-900 dark:text-red-300">
                            Hủy
                        </span>
                        <span v-else
                            class="bg-blue-100 text-blue-800 text-xs font-medium me-2 px-2.5 py-0.5 rounded-full dark:bg-blue-900 dark:text-blue-300">
                            Default
                        </span>
                    </div>
                </div>
            </div>
            <div v-if="showDetail" class="grid gap-2 p-2">
                <div class="col-span-2 flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Tình trạng:</label>
                    <div class="flex-1 text-left">{{ appointmentDetail?.patientCondition }}</div>
                </div>
                <div class="col-span-2 flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Quá trình:</label>
                    <div class="flex-1 text-left">{{ appointmentDetail?.treatmentProvided }}</div>
                </div>
                <div class="col-span-2 flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Lưu ý:</label>
                    <div class="flex-1 text-left">{{ appointmentDetail?.notes }}</div>
                </div>
                <div class="col-span-2 flex items-center">
                    <label class="text-sm font-medium text-gray-900 dark:text-white w-1/4">Ngày đề xuất:</label>
                    <div class="flex-1 text-left">{{ formatDate(appointmentDetail?.nextAppointmentDate) }}</div>
                </div>
            </div>
            <div class="flex justify-end">
                <div>
                    <button type="button" @click="saveUpdate" v-if="selectedAppointment?.status === 'Pending'"
                        class="mr-3 text-white inline-flex items-center bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">
                        Lưu thay đổi
                    </button>
                    <button type="button" @click="cancelAppointment"
                        v-if="selectedAppointment?.status === 'Pending' || selectedAppointment?.status === 'Scheduled'"
                        class="mr-3 focus:outline-none text-white bg-red-600 hover:bg-red-800 focus:ring-4 focus:ring-red-300 font-medium rounded-lg text-sm px-5 py-2.5 me-2 mb-2 dark:bg-red-600 dark:hover:bg-red-700 dark:focus:ring-red-900">
                        Hủy lịch hẹn
                    </button>
                </div>
                <button type="button" @click="openReviewModal" v-if="selectedAppointment?.status === 'Completed'"
                    class="text-gray-900 bg-white border border-gray-300 focus:outline-none hover:bg-gray-100 focus:ring-4 focus:ring-gray-100 font-medium rounded-lg text-sm px-5 py-2.5 me-2 mb-2 dark:bg-gray-800 dark:text-white dark:border-gray-600 dark:hover:bg-gray-700 dark:hover:border-gray-600 dark:focus:ring-gray-700">
                    Đánh giá
                </button>
            </div>
        </div>
    </div>
    <div v-show="isShowReview" tabindex="-1" aria-hidden="true" @click.self="closeReviewModal"
        class="fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-50">
        <div class="relative p-4 w-full max-w-md bg-white rounded-lg shadow dark:bg-gray-700">
            <div class="flex items-center justify-between p-4 md:p-2 border-b rounded-t dark:border-gray-600">
                <h3 class="text-lg font-semibold text-gray-900 dark:text-white">
                    Đánh giá buổi hẹn
                </h3>
                <button type="button" @click="closeReviewModal"
                    class="text-gray-400 bg-transparent hover:bg-gray-200 hover:text-gray-900 rounded-lg text-sm w-8 h-8 inline-flex justify-center items-center dark:hover:bg-gray-600 dark:hover:text-white">
                    <svg class="w-3 h-3" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none"
                        viewBox="0 0 14 14">
                        <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                            d="m1 1 6 6m0 0 6 6M7 7l6-6M7 7l-6 6" />
                    </svg>
                    <span class="sr-only">Close modal</span>
                </button>
            </div>
            <div v-if="!hasReview">
                <div class="grid gap-2 mb-2 p-2">
                    <div class="col-span-2 flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/3">Đánh giá buổi
                            hẹn:
                            <span class="text-red-600 text-sm">*</span>
                        </label>
                        <div class="star-rating">
                            <span v-for="star in maxStars" :key="star" @click="setAppRating(star)"
                                @mouseover="hoverAppRating = star" @mouseleave="hoverAppRating = 0" class="star"
                                :class="{ filled: star <= (hoverAppRating || review.appointmentRating) }">
                                ★
                            </span>
                        </div>
                    </div>

                    <div class="col-span-2 flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/3">Nhận xét buổi
                            hẹn:
                            <span class="text-red-600 text-sm">*</span>
                        </label>
                        <textarea v-model="review.appointmentComment"
                            class="border rounded p-1 w-2/3 bg-gray-50 border-gray-300 text-gray-900 text-sm focus:ring-blue-500 focus:border-blue-500 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                            rows="2"></textarea>
                    </div>

                    <div class="col-span-2 flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/3">Đánh giá nhân
                            viên:
                            <span class="text-red-600 text-sm">*</span>
                        </label>
                        <div class="star-rating">
                            <span v-for="star in maxStars" :key="star" @click="setStaffRating(star)"
                                @mouseover="hoverStaffRating = star" @mouseleave="hoverStaffRating = 0" class="star"
                                :class="{ filled: star <= (hoverStaffRating || review.staffRating) }">
                                ★
                            </span>
                        </div>
                    </div>

                    <!-- Staff Comment -->
                    <div class="col-span-2 flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/3">Nhận xét nhân
                            viên:
                            <span class="text-red-600 text-sm">*</span>
                        </label>
                        <textarea v-model="review.staffComment"
                            class="border rounded p-1 w-2/3 bg-gray-50 border-gray-300 text-gray-900 text-sm focus:ring-blue-500 focus:border-blue-500 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                            rows="2"></textarea>
                    </div>
                </div>

                <!-- Submit Button -->
                <div class="flex justify-end mt-4">
                    <button type="button" @click="sendReview"
                        class="text-white inline-flex items-center bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">
                        Gửi
                    </button>
                </div>
            </div>
            <div v-else>
                <div class="grid gap-2 mb-2 p-2">
                    <div class="col-span-2 flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Đánh giá buổi
                            hẹn:</label>
                        <div class="flex-1 text-left">
                            <div class="flex items-center">
                                <template v-for="star in 5" :key="star">
                                    <svg :class="star <= review?.appointmentRating ? 'w-4 h-4 text-yellow-300' : 'w-4 h-4 text-gray-300 dark:text-gray-500'"
                                        aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor"
                                        viewBox="0 0 22 20">
                                        <path
                                            d="M20.924 7.625a1.523 1.523 0 0 0-1.238-1.044l-5.051-.734-2.259-4.577a1.534 1.534 0 0 0-2.752 0L7.365 5.847l-5.051.734A1.535 1.535 0 0 0 1.463 9.2l3.656 3.563-.863 5.031a1.532 1.532 0 0 0 2.226 1.616L11 17.033l4.518 2.375a1.534 1.534 0 0 0 2.226-1.617l-.863-5.03L20.537 9.2a1.523 1.523 0 0 0 .387-1.575Z" />
                                    </svg>
                                </template>
                            </div>
                        </div>
                    </div>
                    <div class="col-span-2 flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Nhận xét buổi
                            hẹn:</label>
                        <div class="flex-1 text-left">{{ review?.appointmentComment }}</div>
                    </div>
                    <div class="col-span-2 flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Đánh giá nhân
                            viên:</label>
                        <div class="flex-1 text-left">
                            <div class="flex items-center">
                                <template v-for="star in 5" :key="star">
                                    <svg :class="star <= review?.staffRating ? 'w-4 h-4 text-yellow-300' : 'w-4 h-4 text-gray-300 dark:text-gray-500'"
                                        aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor"
                                        viewBox="0 0 22 20">
                                        <path
                                            d="M20.924 7.625a1.523 1.523 0 0 0-1.238-1.044l-5.051-.734-2.259-4.577a1.534 1.534 0 0 0-2.752 0L7.365 5.847l-5.051.734A1.535 1.535 0 0 0 1.463 9.2l3.656 3.563-.863 5.031a1.532 1.532 0 0 0 2.226 1.616L11 17.033l4.518 2.375a1.534 1.534 0 0 0 2.226-1.617l-.863-5.03L20.537 9.2a1.523 1.523 0 0 0 .387-1.575Z" />
                                    </svg>
                                </template>
                            </div>
                        </div>
                    </div>
                    <div class="col-span-2 flex items-center">
                        <label class="text-sm font-medium text-gray-900 dark:text-white w-1/2">Nhận xét nhân
                            viên:</label>
                        <div class="flex-1 text-left">{{ review?.staffComment }}</div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import axios from 'axios';
import BottomNav from './BottomNav.vue';
import Spinner from '../Common/Spinner.vue';
import Toast from '../Common/Toast.vue';

export default {
    name: 'SubscriptionDetail',
    components: {
        BottomNav,
        Spinner,
        Toast
    },
    data() {
        const today = new Date();
        return {
            subscription: {
                patientFullName: '',
                servicePackageName: '',
                usedSessions: 0,
                subscriptionDate: '',
                startDate: '',
                endDate: '',
                status: '',
                total: '',
                isPaid: '',
                paymentDate: ''
            },
            subscriptionId: '',
            appointments: [],
            isModalCreateVisible: false,
            isModalCancelVisible: false,
            appointment: {
                subscriptionId: '',
                appointmentDate: '',
                staffId: null,
                shiftId: '',
                address: '',
                phone: '',
                note: '',
                status: 0
            },
            btnAdd: false,
            btnPay: false,
            btnCancel: false,
            isHandle: false,
            shifts: [],
            isShowDetail: false,
            selectedAppointment: null,
            selectedAppUpdate: {
                subscriptionId: '',
                appointmentDate: '',
                staffId: null,
                shiftId: '',
                address: '',
                phone: '',
                note: '',
                status: 0
            },
            showDetail: false,
            showReview: false,
            isShowReview: false,
            hasReview: false,
            review:{
                appointmentId: '',
                appointmentRating: 5,
                appointmentComment: 'Tốt',
                staffRating: 5,
                staffComment: 'Tốt'
            },
            maxStars: 5,
            hoverAppRating: 0,
            hoverStaffRating: 0,
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
            this.subscriptionId = this.$route.params.id;
            try {
                const response = await fetch(`https://localhost:7072/api/subscription/${this.subscriptionId}`);
                if (response.ok) {
                    const data = await response.json();
                    this.subscription = {
                        ...data,
                        startDate: new Date(data.startDate).toLocaleDateString('en-GB'),
                        endDate: new Date(data.endDate).toLocaleDateString('en-GB'),
                        subscriptionDate: new Date(data.subscriptionDate).toLocaleDateString('en-GB')
                    };                    
                    if (this.subscription.status == "Pending") {
                        this.btnPay = true;
                        this.btnCancel = true;
                    }
                    else {
                        this.btnPay = false;
                        this.btnCancel = false;
                    }
                    if (this.subscription.status == "Active") {
                        this.btnAdd = true;
                    }                    
                } else {
                    this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
                }
                const res2 = await fetch(`https://localhost:7072/api/appointment/subscription/${this.subscriptionId}`);
                if (response.ok) {
                    const data = await res2.json();
                    this.appointments = {
                        ...data,
                    };
                } else {
                    this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
                }
                this.appointment.subscriptionId = this.subscriptionId;
                const res3 = await axios.get('https://localhost:7072/api/shift');
                this.shifts = res3.data;

                const res4 = await fetch(`https://localhost:7072/api/user/sub-addr/${this.subscriptionId}`);
                if (res4.ok) {
                    const data = await res4.json();
                    this.appointment.address = data.address;
                    this.appointment.phone = data.phone;
                } else {
                    this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
                }
            } catch (error) {
                this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
            }
        },
        async cancelSubscription() {
            try {
                this.isHandle = true;
                const response = await fetch(`https://localhost:7072/api/subscription/${this.subscriptionId}`, {
                    method: 'DELETE',
                    headers: {
                        'Content-Type': 'application/json',
                    }
                });

                if (response.ok) {
                    this.showSuccessToast("Hủy đăng ký dịch vụ thành công.");
                    location.reload();
                } else {
                    this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
                }
            } catch (error) {
                this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
            }
            finally{
                this.isHandle = false;
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
                    this.showSuccessToast("Hủy lịch hẹn thành công.");
                    location.reload();
                } else {
                    this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
                }
            } catch (error) {
                this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
            }
            finally{
                this.isHandle = false;
            }
        },
        async openDetailModal(id) {
            try {
                const response = await fetch(`https://localhost:7072/api/appointment/${id}`);

                if (!response.ok) {
                    this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
                }
                const appointment = await response.json();

                this.selectedAppointment = appointment;
                if (appointment.appointmentDetailDto) {
                    this.appointmentDetail = appointment.appointmentDetailDto;
                    this.showDetail = true;
                }
                this.isShowDetail = true;

            } catch (error) {
                this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
            }
        },        

        async addAppointment() {
            try {
                this.isHandle = true;
                const response = await fetch('https://localhost:7072/api/appointment', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(this.appointment),
                });

                if (response.ok) {
                    this.showSuccessToast("Thêm lịch hẹn thành công.");
                    location.reload();
                } else {
                    this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
                }
            } catch (error) {
                this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
            }
            finally{
                this.isHandle = false;
            }
        },

        async payment() {
            try{
                this.isHandle = true;
                const reqData = {
                    orderId: this.subscriptionId,
                    amount: this.subscription.total
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
                    this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
                }
            }
            catch(error){
                this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
            }
            finally{
                this.isHandle = false;
            }
        },

        async saveUpdate() {
            this.selectedAppUpdate.subscriptionId = this.selectedAppointment.subscriptionId;
            this.selectedAppUpdate.shiftId = this.selectedAppointment.shiftId;
            this.selectedAppUpdate.appointmentDate = this.selectedAppointment.appointmentDate;
            this.selectedAppUpdate.address = this.selectedAppointment.address;
            this.selectedAppUpdate.phone = this.selectedAppointment.phone;
            this.selectedAppUpdate.note = this.selectedAppointment.note;

            // Validate required fields
            if (!this.selectedAppUpdate.appointmentDate) {
                this.showErrorToast("Vui lòng chọn ngày hẹn.");
                return;
            }
            if (!this.selectedAppUpdate.shiftId) {
                this.showErrorToast("Vui lòng chọn ca làm việc.");
                return; 
            }
            if (!this.selectedAppUpdate.address) {
                this.showErrorToast("Vui lòng chọn ca địa chỉ.");
                return;
            }
            if (!this.selectedAppUpdate.phone) {
                this.showErrorToast("Vui lòng chọn ca số điện thoại.");
                return; 
            }

            try {
                this.isHandle = true;
                const response = await fetch(`https://localhost:7072/api/appointment/${this.selectedAppointment.id}`, {
                    method: 'PUT',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(this.selectedAppUpdate),
                });
                if (response.ok) {
                    this.showSuccessToast("Cập nhật thông tin buổi hẹn thành công.");
                    location.reload();
                } else {
                    this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
                }
            } catch (err) {
                this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
            }
            finally{
                this.isHandle = false;
            }
        },

        async sendReview() {
            try {
                this.isHandle = true;
                this.review.appointmentId = this.selectedAppointment.id;                
                const response = await fetch(`https://localhost:7072/api/appointment/review-send`, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(this.review),
                });

                if (response.ok) {
                    this.showSuccessToast("Đánh giá buổi hẹn thành công.");
                    location.reload();
                } else {
                    this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
                }
            } catch (error) {
                this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
            }
            finally{
                this.isHandle = false;
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
        openCrudModal() {
            this.isModalCreateVisible = true;
        },

        closeCrudModal() {
            this.isModalCreateVisible = false;
        },

        openCancelModal() {
            this.isModalCancelVisible = true;
        },

        closeCancelModal() {
            this.isModalCancelVisible = false;
        },

        openReviewModal() {
            if(this.selectedAppointment.appointmentReviewDto){
                this.review = this.selectedAppointment.appointmentReviewDto;
                this.hasReview = true;
            }
            this.isShowReview = true;
        },

        closeReviewModal() {
            this.isShowReview = false;
            this.review.appointmentId = '';
            this.review.staffRating = 5;
            this.review.staffComment = 'Tốt';
            this.review.appointmentRating = 5;
            this.review.appointmentComment = 'Tốt';
            this.hasReview = false;
        },

        closeDetailModal() {
            this.isShowDetail = false;
            this.selectedAppointment = null;
            this.appointmentDetail = null;
            this.showDetail = false;
            this.staffs = [];
        },

        formatPrice(value) {
            return new Intl.NumberFormat('vi-VN').format(value);
        },
        formatDate(dateString) {
            const date = new Date(dateString);
            return date.toLocaleDateString('vi-VN', { day: '2-digit', month: '2-digit', year: 'numeric' });
        },
        setAppRating(star) {
            this.review.appointmentRating = star;
        },
        setStaffRating(star) {
            this.review.staffRating = star;
        },
    },
    computed: {
        formattedAppointmentDate: {
            get() {
                if (!this.selectedAppointment?.appointmentDate) return ''; 
                const date = new Date(this.selectedAppointment.appointmentDate);
                var dateVN = this.selectedAppointment.appointmentDate || '';
                return dateVN.split('T')[0];
            },
            set(newDate) {
                this.selectedAppointment.appointmentDate = new Date(newDate).toISOString();
            }
        },
        minDate() {
            let today = new Date();
            today.setDate(today.getDate() + 0); // Set to tomorrow's date
            return today.toISOString().split('T')[0]; // Format as YYYY-MM-DD
        }
    }
}
</script>
<style>
/* Optional: Style adjustments for icons */
.hidden {
    display: none;
}
.star {
    font-size: 2rem;
    cursor: pointer;
    color: lightgray;
  }
  
  .star.filled {
    color: gold;
  }
</style>