<script>
import GroupedColumnChart from './GroupedColumnChart.vue';
import NumberFigure from './NumberFigure.vue';
import PieChart from './PieChart.vue';
import ReviewStat from './ReviewStat.vue';

export default {
    name: "Home",
    components: {
        NumberFigure,
        PieChart,
        GroupedColumnChart,
        ReviewStat
    },
}
</script>

<template>
    <div class="relative p-4 overflow-x-auto shadow-md sm:rounded-lg">
        <h3 class="text-3xl font-extrabold dark:text-white mb-5">Tổng quan</h3>
        <NumberFigure />
        <PieChart />
        <GroupedColumnChart />
    </div>
</template>
