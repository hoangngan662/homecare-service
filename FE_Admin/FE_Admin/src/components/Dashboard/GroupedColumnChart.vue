<script>
import ApexCharts from 'apexcharts';

export default {
    name: "GroupedColumnChart",
    data() {
        return {
            chart: null,
            options: {
                colors: ["#1A56DB", "#FDBA8C"],
                series: [],
                chart: {
                    type: "bar",
                    height: "320px",
                    fontFamily: "Inter, sans-serif",
                    toolbar: {
                        show: false,
                    },
                },
                plotOptions: {
                    bar: {
                        horizontal: false,
                        columnWidth: "70%",
                        borderRadiusApplication: "end",
                        borderRadius: 8,
                    },
                },
                tooltip: {
                    shared: true,
                    intersect: false,
                    style: {
                        fontFamily: "Inter, sans-serif",
                    },
                    // Hiển thị tên dịch vụ ở hàng header của tooltip
                    x: {
                        formatter: (val) => {
                            return `${val}`; // Tiêu đề header
                        }
                    },
                    y: {
                        formatter: (val) => {
                            return `${val}`; // Giá trị
                        }
                    }
                },
                stroke: {
                    show: true,
                    width: 0,
                    colors: ["transparent"],
                },
                grid: {
                    show: false,
                    strokeDashArray: 4,
                    padding: {
                        left: 2,
                        right: 2,
                        top: -14
                    },
                },
                dataLabels: {
                    enabled: false,
                },
                legend: {
                    show: true,
                },
                xaxis: {
                    labels: {
                        show: true,
                        rotate: 0, // Xoay chữ ngang
                        style: {
                            fontFamily: "Inter, sans-serif",
                            cssClass: 'text-xs font-normal fill-gray-500 dark:fill-gray-400',
                            fontSize: '12px'
                        },
                        // Cắt bớt nội dung quá dài và thêm dấu '...'
                        formatter: (val) => {
                            // Bỏ chữ "Dịch vụ" và cắt bớt nếu cần
                            const trimmedVal = val.replace("Dịch vụ ", ""); // Bỏ chữ "Dịch vụ"
                            return trimmedVal.length > 8 ? trimmedVal.substring(0, 8) + "..." : trimmedVal;
                        },
                        hideOverlappingLabels: true // Ẩn nếu quá gần nhau
                    },
                    axisBorder: {
                        show: false,
                    },
                    axisTicks: {
                        show: false,
                    },
                },
                yaxis: {
                    show: false,
                },
                fill: {
                    opacity: 1,
                },
            }
        };
    },
    mounted() {
        this.fetchData();
    },
    methods: {
        async fetchData() {
            try {
                const response = await fetch("https://localhost:7072/api/stats/sub-app");
                const data = await response.json();

                // Chuyển đổi dữ liệu cho biểu đồ
                this.options.series = [
                    {
                        name: "Tổng số lượt đăng ký",
                        data: data.map(item => ({ x: item.serviceTypeName, y: item.totalSubscriptions }))
                    },
                    {
                        name: "Tổng số buổi hẹn",
                        data: data.map(item => ({ x: item.serviceTypeName, y: item.totalAppointments }))
                    }
                ];

                this.renderChart();
            } catch (error) {
                console.error("Error fetching data:", error);
            }
        },
        renderChart() {
            if (document.getElementById("column-chart")) {
                if (this.chart) {
                    this.chart.destroy();
                }
                this.chart = new ApexCharts(document.getElementById("column-chart"), this.options);
                this.chart.render();
            }
        }
    }
}
</script>


<template>
    <div class="flex justify-between mb-3">
        <div class="flex justify-center items-center">
            <h5 class="text-xl font-bold leading-none text-gray-900 dark:text-white pe-1">Lượt sử dụng dịch vụ</h5>
        </div>
    </div>
    <div id="column-chart"></div>
</template>
