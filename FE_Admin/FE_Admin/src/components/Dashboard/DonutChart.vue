<script>
import ApexCharts from 'apexcharts';
export default {
    name: "DonutChart",
    data() {
        return {
            series: [],
            labels: [],
            totalRevenue: 0,
            colors: [],
        };
    },
    mounted() {
        this.fetchData();
    },
    methods: {
        async fetchData() {
            try {
                const response = await fetch('https://localhost:7072/api/stats/service-type');
                const data = await response.json();

                // Kiểm tra dữ liệu nhận được
                console.log(data); // Kiểm tra cấu trúc dữ liệu

                if (data.revenueByServiceType && Array.isArray(data.revenueByServiceType)) {
                    this.series = data.revenueByServiceType.map(item => item.totalRevenue);
                    this.labels = data.revenueByServiceType.map(item => item.serviceTypeName);
                    this.colors = this.generateColors(this.series.length);
                } else {
                    console.error('No revenueByServiceType data found or it is not an array');
                    this.series = []; // Gán giá trị mặc định
                    this.labels = []; // Gán giá trị mặc định
                }

                // Cập nhật tổng doanh thu
                this.totalRevenue = data.totalRevenue || 0; // Gán 0 nếu không có tổng doanh thu

                // Gọi hàm để render biểu đồ
                this.renderChart();
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        },
        formatPrice(value) {
            return new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(value);
        },
        generateColors(num) {
            const colorPalette = [
                "#1C64F2", "#16BDCA", "#FDBA8C", "#E74694",
                "#8E44AD", "#F39C12", "#D35400", "#2ECC71",
                "#3498DB", "#9B59B6", "#E67E22", "#2C3E50",
                "#F56C42", "#7DCEA0", "#F39C12", "#5D6D7E",
                "#F0B27A", "#A569BD", "#45B39D", "#D5DBDB"
            ];
            return colorPalette.slice(0, num);
        },
        getChartOptions() {
            return {
                series: this.series,
                colors: this.colors,
                chart: {
                    height: 350,
                    width: "100%",
                    type: "donut",
                },
                stroke: {
                    colors: ["transparent"],
                    lineCap: "",
                },
                plotOptions: {
                    pie: {
                        donut: {
                            labels: {
                                show: true,
                                name: {
                                    show: true,
                                    fontFamily: "Inter, sans-serif",
                                    offsetY: 20,
                                },
                                total: {
                                    showAlways: true,
                                    show: true,
                                    label: "Tổng doanh thu",
                                    fontFamily: "Inter, sans-serif",
                                    style: {
                                        fontSize: '14px',
                                    },
                                    formatter: (w) => {
                                        const sum = w.globals.seriesTotals.reduce((a, b) => {
                                            return a + b;
                                        }, 0);
                                        return this.formatPrice(sum); // Sử dụng hàm formatPrice
                                    },
                                },
                                value: {
                                    show: true,
                                    fontFamily: "Inter, sans-serif",
                                    offsetY: -20,
                                    formatter: (value) => {
                                        return this.formatPrice(value); // Sử dụng hàm formatPrice
                                    },
                                },
                            },
                            size: "80%",
                        },
                    },
                },
                grid: {
                    padding: {
                        top: -2,
                    },
                },
                labels: this.labels, // Sử dụng labels từ dữ liệu API
                dataLabels: {
                    enabled: false,
                },
                legend: {
                    position: "right",
                    fontFamily: "Inter, sans-serif",
                },
                yaxis: {
                    labels: {
                        formatter: (value) => {
                            return this.formatPrice(value); // Sử dụng hàm formatPrice
                        },
                    },
                },
                xaxis: {
                    labels: {
                        formatter: (value) => {
                            return this.formatPrice(value); // Sử dụng hàm formatPrice
                        },
                    },
                    axisTicks: {
                        show: false,
                    },
                    axisBorder: {
                        show: false,
                    },
                },
            }
        },
        renderChart() {
            if (document.getElementById("donut-chart") && typeof ApexCharts !== 'undefined') {
                const chart = new ApexCharts(document.getElementById("donut-chart"), this.getChartOptions());
                chart.render();
            }
        },
    }
}
</script>
<template>
    <div class="flex justify-between mb-3">
        <div class="flex justify-center items-center">
            <h5 class="text-xl font-bold leading-none text-gray-900 dark:text-white pe-1">Tổng doanh thu</h5>
        </div>
    </div>    
    <!-- Donut Chart -->
    <div class="py-6" id="donut-chart"></div>
</template>