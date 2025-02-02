<template>
    <div class="relative p-4 overflow-x-auto shadow-md sm:rounded-lg">
        <h3 class="text-3xl font-extrabold dark:text-white mb-5">Báo cáo</h3>

        <div class="max-w-sm flex items-center space-x-4">
            <!-- Month selection -->
            <div class="flex-1">
                <label for="month" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Chọn
                    tháng</label>
                <select v-model="selectedMonth"
                    class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
                    <option value="" selected>Chọn tháng</option>
                    <option v-for="month in months" :key="month" :value="month">{{ month }}</option>
                </select>
            </div>

            <!-- Year selection -->
            <div class="flex-1">
                <label for="year" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">
                    Chọn năm
                    <span class="text-red-600 text-sm">*</span>
                </label>
                <select v-model="selectedYear"
                    class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500">
                    <option v-for="year in years" :key="year" :value="year">{{ year }}</option>
                </select>
            </div>
        </div>
        <button type="button" @click="exportExcel"
            class="mt-4 px-5 py-2.5 text-sm font-medium text-white inline-flex items-center bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 rounded-lg text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">
            <svg class="w-6 h-6 text-white me-2" aria-hidden="true" xmlns="http://www.w3.org/2000/svg"
                fill="currentColor" viewBox="0 0 24 24">
                <path fill-rule="evenodd"
                    d="M13 11.15V4a1 1 0 1 0-2 0v7.15L8.78 8.374a1 1 0 1 0-1.56 1.25l4 5a1 1 0 0 0 1.56 0l4-5a1 1 0 1 0-1.56-1.25L13 11.15Z"
                    clip-rule="evenodd" />
                <path fill-rule="evenodd"
                    d="M9.657 15.874 7.358 13H5a2 2 0 0 0-2 2v4a2 2 0 0 0 2 2h14a2 2 0 0 0 2-2v-4a2 2 0 0 0-2-2h-2.358l-2.3 2.874a3 3 0 0 1-4.685 0ZM17 16a1 1 0 1 0 0 2h.01a1 1 0 1 0 0-2H17Z"
                    clip-rule="evenodd" />
            </svg>
            Xuất báo cáo
        </button>
        <span v-if="statusMessage" :class="statusClass" class="block mt-2 text-sm">
            {{ statusMessage }}
        </span>
    </div>
</template>

<script>
export default {
    name: "Report",
    data() {
        return {
            selectedMonth: '',
            selectedYear: new Date().getFullYear(),
            months: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12],
            years: this.getLastFiveYears(),
            statusMessage: '',
            statusType: '',
        };
    },
    computed: {
        statusClass() {
            return this.statusType === 'success' ? 'text-green-500' : 'text-red-500';
        }
    },
    methods: {
        async exportExcel() {
            console.log("month: " + this.selectedMonth);
            console.log("year: " + this.selectedYear);

            // Define the base API URL for monthly and yearly revenue
            let url = '';
            let fileName = '';

            // Check if a month is selected
            if (this.selectedMonth !== '') {
                // If a month is selected, call the monthly revenue API and set the file name format for monthly report
                url = `https://localhost:7072/api/report/revenue-monthly?month=${this.selectedMonth}&year=${this.selectedYear}`;
                fileName = `Revenue_${String(this.selectedMonth).padStart(2, '0')}-${this.selectedYear}.xlsx`; // Format as Revenue_{month:D2}-{year}.xlsx
            } else {
                // If no month is selected, call the yearly revenue API and set the file name format for yearly report
                url = `https://localhost:7072/api/report/revenue-yearly?year=${this.selectedYear}`;
                fileName = `Revenue_${this.selectedYear}.xlsx`; // Format as Revenue_{year}.xlsx
            }

            // Call the API to fetch the Excel file
            try {
                const response = await fetch(url, {
                    method: 'GET',
                    headers: {
                        'Accept': 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet', // Specify the Excel file format
                    },
                });

                if (response.ok) {
                    const blob = await response.blob();

                    const link = document.createElement('a');
                    link.href = URL.createObjectURL(blob);
                    link.download = fileName;
                    link.click();
                    this.statusMessage = 'Báo cáo đã được xuất thành công!';
                    this.statusType = 'success';
                } else {
                    this.statusMessage = 'Có lỗi xảy ra, vui lòng thử lại!';
                    this.statusType = 'error';
                }
            } catch (error) {
            }
        },

        getLastFiveYears() {
            let currentYear = new Date().getFullYear();
            let years = [];
            for (let i = 0; i < 5; i++) {
                years.push(currentYear - i);
            }
            return years;
        }
    }
}
</script>
