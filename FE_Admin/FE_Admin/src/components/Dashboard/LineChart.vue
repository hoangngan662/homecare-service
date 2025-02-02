<script>
import ApexCharts from 'apexcharts';

export default {
    name: "LineChart",
    data() {
        return {
            chart: null,
            selectedYear: new Date().getFullYear(), // Mặc định là năm hiện tại
            years: Array.from({ length: 5 }, (_, i) => new Date().getFullYear() - i), // 5 năm trở lại đây
            monthlyData: Array(12).fill(0), // Khởi tạo dữ liệu tháng
            months: [], // Dùng để lưu tên các tháng từ API
            showDropdown: false, // Trạng thái hiển thị dropdown
        };
    },
    mounted() {
        this.fetchAnnualData(this.selectedYear); // Lấy dữ liệu năm hiện tại khi khởi động
    },
    methods: {
        async fetchAnnualData(year) {
            try {
                const response = await fetch(`https://localhost:7072/api/stats/annual/${year}`);
                const data = await response.json();
                console.log(data);
                
                // Cập nhật dữ liệu biểu đồ và tên tháng từ API
                this.monthlyData = data.monthlyRevenues.map(item => item.totalRevenue);
                this.months = data.monthlyRevenues.map(item => item.month);

                this.updateChart();
            } catch (error) {
                console.error("Error fetching annual data:", error);
            }
        },
        updateChart() {
            const options = {
                chart: {
                    height: 300,
                    maxWidth: "100%",
                    type: "line",
                    fontFamily: "Inter, sans-serif",
                    toolbar: { show: false },
                },
                tooltip: { enabled: true, x: { show: false } },
                dataLabels: { enabled: false },
                stroke: { curve: "smooth", width: 6 },
                grid: {
                    show: true,
                    strokeDashArray: 4,
                    padding: { left: 2, right: 2, top: -26 },
                },
                series: [
                    { name: "Doanh thu", data: this.monthlyData, color: "#1A56DB" },
                ],
                xaxis: {
                    categories: this.months, // Sử dụng danh sách tháng từ API
                    labels: {
                        show: true,
                        style: {
                            fontFamily: "Inter, sans-serif",
                            cssClass: "text-xs font-normal fill-gray-500 dark:fill-gray-400",
                        },
                    },
                    axisBorder: { show: false },
                    axisTicks: { show: false },
                },
                yaxis: {
                    show: true,
                    labels: {
                        formatter: function (value) {
                            return new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(value);
                        },
                    },
                },
                legend: { show: false },
            };

            if (!this.chart) {
                this.chart = new ApexCharts(document.getElementById("line-chart"), options);
                this.chart.render();
            } else {
                this.chart.updateOptions(options);
            }
        },
        handleYearChange(year) {
            this.selectedYear = year;
            // Gọi dữ liệu mới cho năm đã chọn
            this.fetchAnnualData(year);
            this.showDropdown = false; // Ẩn dropdown khi chọn xong
        },
        toggleDropdown() {
            this.showDropdown = !this.showDropdown; // Chuyển đổi trạng thái hiển thị dropdown
        },
    },
};
</script>

<template>
    <div class="flex justify-between mb-5">
        <div class="flex justify-center items-center">
            <h5 class="text-xl font-bold leading-none text-gray-900 dark:text-white pe-1">
                Doanh thu theo năm
            </h5>
        </div>
        <div class="relative"> <!-- Thêm lớp relative để đảm bảo dropdown không nhảy -->
            <button id="dropdownDefaultButton" @click="toggleDropdown" type="button"
                class="px-3 py-2 inline-flex items-center text-sm font-medium text-gray-900 focus:outline-none bg-white rounded-lg border border-gray-200 hover:bg-gray-100 hover:text-blue-700 focus:z-10 focus:ring-4 focus:ring-gray-200 dark:focus:ring-gray-700 dark:bg-gray-800 dark:text-gray-400 dark:border-gray-600 dark:hover:text-white dark:hover:bg-gray-700">
                {{ selectedYear }}
                <svg class="w-2.5 h-2.5 ms-2.5" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none"
                    viewBox="0 0 10 6">
                    <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                        d="m1 1 4 4 4-4" />
                </svg>
            </button>
            <div v-if="showDropdown"
                class="absolute z-10 bg-white divide-y divide-gray-100 rounded-lg shadow w-44 dark:bg-gray-700">
                <ul class="py-2 text-sm text-gray-700 dark:text-gray-200" aria-labelledby="dropdownDefaultButton">
                    <li v-for="year in years" :key="year">
                        <button @click.prevent="handleYearChange(year)"
                            class="w-full text-left block px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white">
                            {{ year }}
                        </button>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div id="line-chart"></div>
</template>

<style>
.chart-container {
    width: 100%;
    max-width: 600px;
    margin: auto;
}
</style>
