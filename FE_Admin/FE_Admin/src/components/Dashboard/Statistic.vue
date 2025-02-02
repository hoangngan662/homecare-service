<script>
import DonutChart from './DonutChart.vue';
import GroupedColumnChart from './GroupedColumnChart.vue';
import LineChart from './LineChart.vue';
import NumberFigure from './NumberFigure.vue';
import PieChart from './PieChart.vue';
import ReviewStat from './ReviewStat.vue';

export default {
    name: "Statistic",
    components: {
        NumberFigure,
        PieChart,
        DonutChart,
        GroupedColumnChart,
        LineChart,
        ReviewStat
    },
}
</script>

<template>
    <div class="relative p-4 overflow-x-auto shadow-md sm:rounded-lg">
        <h3 class="text-3xl font-extrabold dark:text-white mb-5">Thống kê</h3>
        <NumberFigure />
        <PieChart />
        <GroupedColumnChart />
        <DonutChart />
        <LineChart />
        <ReviewStat/>
    </div>
</template>
