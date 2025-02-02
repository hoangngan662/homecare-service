<script>
import ApexCharts from 'apexcharts';

export default {
    name: "PieChart",
    data() {
        return {
            chart: null,
            options: {
                series: [],
                colors: ["#1C64F2", "#16BDCA", "#9061F9", "#FF6384", "#36A2EB", "#FFCE56"], // Các màu sắc khác nhau
                chart: {
                    height: 320,
                    width: "100%",
                    type: "pie",
                },
                stroke: {
                    colors: ["white"],
                },
                plotOptions: {
                    pie: {
                        labels: {
                            show: true,
                        },
                        size: "100%",
                        dataLabels: {
                            offset: -25
                        }
                    },
                },
                labels: [],
                dataLabels: {
                    enabled: true,
                    style: {
                        fontFamily: "Inter, sans-serif",
                    },
                },
                legend: {
                    position: "bottom",
                    fontFamily: "Inter, sans-serif",
                    horizontalAlign: "center",
                    itemMargin: {
                        horizontal: 10,
                        vertical: 5,
                    },
                    markers: {
                        width: 10,
                        height: 10,
                    },
                    formatter: function (seriesName, opts) {
                        return `${seriesName}: ${opts.w.globals.series[opts.seriesIndex]}%`;
                    },
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
                const response = await fetch("https://localhost:7072/api/stats/patient-age");
                if (!response.ok) {
                    throw new Error(`HTTP error! status: ${response.status}`);
                }
                const data = await response.json();

                // Kiểm tra dữ liệu nhận được
                console.log(data);

                // Cập nhật series và labels cho biểu đồ
                this.options.series = data.map(item => item.count); // Sử dụng 'count' thay vì 'percentage'
                this.options.labels = data.map(item => item.ageGroup);

                // Kiểm tra series và labels trước khi vẽ biểu đồ
                if (this.options.series.length === 0 || this.options.labels.length === 0) {
                    console.error("Series or labels are empty.");
                    return;
                }

                // Vẽ biểu đồ
                this.renderChart();
            } catch (error) {
                console.error("Error fetching data:", error);
            }
        },
        renderChart() {
            if (document.getElementById("pie-chart")) {
                // Nếu đã có biểu đồ thì hủy nó trước khi tạo mới
                if (this.chart) {
                    this.chart.destroy();
                }
                // Tạo mới biểu đồ với options hiện tại
                this.chart = new ApexCharts(document.getElementById("pie-chart"), this.options);
                this.chart.render().catch(err => console.error("Error rendering chart:", err));
            }
        }
    },
}
</script>

<template>
    <div class="flex justify-between mb-3">
        <div class="flex justify-center items-center">
            <h5 class="text-xl font-bold leading-none text-gray-900 dark:text-white pe-1">Độ tuổi khách hàng</h5>
        </div>
    </div>

    <div class="py-6" id="pie-chart"></div>
</template>
