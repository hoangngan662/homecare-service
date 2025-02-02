<template>
  <Spinner v-if="isHandle" />
  <div class="relative p-4 overflow-x-auto shadow-md sm:rounded-lg">
    <h3 class="text-2xl font-extrabold dark:text-white">Thêm khách hàng</h3>
    <br />
    <form @submit.prevent="addPatient">
      <div class="grid gap-6 mb-6 md:grid-cols-2">
        <div>
          <label for="fullname" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Họ và
            tên
            <span class="text-red-600 text-sm">*</span>
          </label>
          <input type="text" id="fullname" v-model="patient.fullname"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            placeholder="Nguyen Van A" required />
        </div>
        <div>
          <label for="dob" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Ngày
            sinh
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
            <input id="dob" type="date" v-model="patient.doB"
              class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full ps-10 p-2.5  dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
              placeholder="Chọn ngày sinh" required>
          </div>
        </div>
        <div>
          <label for="email" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Email
            <span class="text-red-600 text-sm">*</span>
          </label>
          <input type="email" id="email" v-model="patient.email"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            placeholder="nguyena@example.com" required />
        </div>
        <div>
          <label for="phone" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Số điện
            thoại
            <span class="text-red-600 text-sm">*</span>
          </label>
            
          <input type="tel" id="phone" v-model="patient.phoneNumber"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            placeholder="0123456789" pattern="^[0-9]{8,12}$" required />
        </div>
        <div>
          <label for="address" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Địa
            chỉ
            <span class="text-red-600 text-sm">*</span>
          </label>
          <input type="text" id="address" v-model="patient.address"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            placeholder="123 Ninh Kieu" required />
        </div>
        <div>
          <label for="password" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Mật
            khẩu
            <span class="text-red-600 text-sm">*</span>
          </label>
          <input type="password" id="password" v-model="patient.password"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            placeholder="•••••••••" required />
        </div>
      </div>
      <button type="submit"
        class="text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">Thêm</button>
      <router-link to="/patient" class="ml-3 font-medium text-blue-600 dark:text-blue-500 hover:underline">Quay
        lại</router-link>
    </form>
  </div>
</template>

<script>
import Spinner from '../Common/Spinner.vue';

export default {
  name: 'AddPatient',
  components:{
    Spinner
  },
  data() {
    return {
      patient: {
        fullname: '',
        address: '',
        email: '',
        phoneNumber: '',
        password: '',
        doB: '',
        specialization: null,
        startDate: null,
        roles: ['Patient'],
      },
      isHandle: false
    };
  },
  methods: {
    async addPatient() {
      try {
        this.isHandle = true;
        const response = await fetch('https://localhost:7072/api/user', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(this.patient),
        });

        if (response.ok) {
          alert('Thêm khách hàng thành công!');
          this.$router.push('/patient');
        } else {
          alert('Thêm khách hàng thất bại.');
          this.isHandle = false;
        }
      } catch (error) {
        console.error('Error:', error);
        alert('Có lỗi xảy ra. Hãy thử lại.');
      }
    },
  },
}
</script>