<script>
import axios from 'axios';
export default {
    name: "ReviewStat",
    data() {
        return {
            reviewStat: {
                totalReviews: 0,
                starCount: [0, 0, 0, 0, 0], 
                avgStar: 0,
                staffStarCount: [0, 0, 0, 0, 0], 
                staffAvgStar: 0,
            },
        };
    },
    mounted() {
        this.fetchData();
    },
    methods: {
        async fetchData() {
            try {
                const response = await axios.get('https://localhost:7072/api/stats/review');
                this.reviewStat = response.data;
                console.log(response.data);
                
                console.log(this.reviewStat);
            } catch (error) {
                console.error("There was an error fetching the Service Types:", error);
            }
        },
        calculatePercentage(count) {
            return this.reviewStat.totalReviews > 0 ? (count / this.reviewStat.totalReviews) * 100 : 0;
        }
    },
}
</script>
<template>
    <div class="flex">
        <div class="w-1/2 p-2">
            <div class="flex">
                <h5 class="text-xl mb-2 font-bold leading-none text-gray-900 dark:text-white pe-1">Đánh giá dịch vụ
                </h5>
            </div>
            <div class="flex items-center mb-2">
                <!-- Hiển thị các ngôi sao -->
                <template v-for="star in 5">
                    <svg v-if="star <= Math.floor(reviewStat.avgStar)" class="w-4 h-4 text-yellow-300 me-1"
                        aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 22 20"
                        :key="`full-${star}`">
                        <path
                            d="M20.924 7.625a1.523 1.523 0 0 0-1.238-1.044l-5.051-.734-2.259-4.577a1.534 1.534 0 0 0-2.752 0L7.365 5.847l-5.051.734A1.535 1.535 0 0 0 1.463 9.2l3.656 3.563-.863 5.031a1.532 1.532 0 0 0 2.226 1.616L11 17.033l4.518 2.375a1.534 1.534 0 0 0 2.226-1.617l-.863-5.03L20.537 9.2a1.523 1.523 0 0 0 .387-1.575Z" />
                    </svg>
                    <svg v-else class="w-4 h-4 text-gray-300 me-1 dark:text-gray-500" aria-hidden="true"
                        xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 22 20"
                        :key="`empty-${star}`">
                        <path
                            d="M20.924 7.625a1.523 1.523 0 0 0-1.238-1.044l-5.051-.734-2.259-4.577a1.534 1.534 0 0 0-2.752 0L7.365 5.847l-5.051.734A1.535 1.535 0 0 0 1.463 9.2l3.656 3.563-.863 5.031a1.532 1.532 0 0 0 2.226 1.616L11 17.033l4.518 2.375a1.534 1.534 0 0 0 2.226-1.617l-.863-5.03L20.537 9.2a1.523 1.523 0 0 0 .387-1.575Z" />
                    </svg>
                </template>

                <!-- Hiển thị giá trị trung bình -->
                <p class="ms-1 text-sm font-medium text-gray-500 dark:text-gray-400">{{ reviewStat.avgStar.toFixed(2) }}
                </p>
                <p class="ms-1 text-sm font-medium text-gray-500 dark:text-gray-400">/</p>
                <p class="ms-1 text-sm font-medium text-gray-500 dark:text-gray-400">5</p>
            </div>

            <!-- Hiển thị các đánh giá khác -->
            <p class="text-sm font-medium text-gray-500 dark:text-gray-400">{{ reviewStat.totalReviews }} đánh giá</p>
            <div v-for="(count, index) in reviewStat.starCount.slice().reverse()" :key="index"
                class="flex items-center mt-4">
                <a href="#" class="text-sm font-medium text-blue-600 dark:text-blue-500 hover:underline">{{ 5 - index }}
                    sao</a>
                <div class="w-2/4 h-5 mx-4 bg-gray-200 rounded dark:bg-gray-700">
                    <div class="h-5 bg-yellow-300 rounded" :style="{ width: calculatePercentage(count) + '%' }"></div>
                </div>
                <span class="text-sm font-medium text-gray-500 dark:text-gray-400">{{
                    calculatePercentage(count).toFixed(1)
                    }}%</span>
            </div>
        </div>
        <div class="w-1/2 p-2">
            <div class="flex">
                <h5 class="text-xl mb-2 font-bold leading-none text-gray-900 dark:text-white pe-1">Đánh giá nhân viên
                </h5>
            </div>
            <div class="flex items-center mb-2">
                <!-- Hiển thị các ngôi sao -->
                <template v-for="star in 5">
                    <svg v-if="star <= Math.floor(reviewStat.staffAvgStar)" class="w-4 h-4 text-yellow-300 me-1"
                        aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 22 20"
                        :key="`full-${star}`">
                        <path
                            d="M20.924 7.625a1.523 1.523 0 0 0-1.238-1.044l-5.051-.734-2.259-4.577a1.534 1.534 0 0 0-2.752 0L7.365 5.847l-5.051.734A1.535 1.535 0 0 0 1.463 9.2l3.656 3.563-.863 5.031a1.532 1.532 0 0 0 2.226 1.616L11 17.033l4.518 2.375a1.534 1.534 0 0 0 2.226-1.617l-.863-5.03L20.537 9.2a1.523 1.523 0 0 0 .387-1.575Z" />
                    </svg>
                    <svg v-else class="w-4 h-4 text-gray-300 me-1 dark:text-gray-500" aria-hidden="true"
                        xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 22 20"
                        :key="`empty-${star}`">
                        <path
                            d="M20.924 7.625a1.523 1.523 0 0 0-1.238-1.044l-5.051-.734-2.259-4.577a1.534 1.534 0 0 0-2.752 0L7.365 5.847l-5.051.734A1.535 1.535 0 0 0 1.463 9.2l3.656 3.563-.863 5.031a1.532 1.532 0 0 0 2.226 1.616L11 17.033l4.518 2.375a1.534 1.534 0 0 0 2.226-1.617l-.863-5.03L20.537 9.2a1.523 1.523 0 0 0 .387-1.575Z" />
                    </svg>
                </template>

                <!-- Hiển thị giá trị trung bình -->
                <p class="ms-1 text-sm font-medium text-gray-500 dark:text-gray-400">{{
                    reviewStat.staffAvgStar.toFixed(2) }}
                </p>
                <p class="ms-1 text-sm font-medium text-gray-500 dark:text-gray-400">/</p>
                <p class="ms-1 text-sm font-medium text-gray-500 dark:text-gray-400">5</p>
            </div>

            <!-- Hiển thị các đánh giá khác -->
            <p class="text-sm font-medium text-gray-500 dark:text-gray-400">{{ reviewStat.totalReviews }} đánh giá</p>
            <div v-for="(count, index) in reviewStat.staffStarCount.slice().reverse()" :key="index"
                class="flex items-center mt-4">
                <a href="#" class="text-sm font-medium text-blue-600 dark:text-blue-500 hover:underline">{{ 5 - index }}
                    sao</a>
                <div class="w-2/4 h-5 mx-4 bg-gray-200 rounded dark:bg-gray-700">
                    <div class="h-5 bg-yellow-300 rounded" :style="{ width: calculatePercentage(count) + '%' }"></div>
                </div>
                <span class="text-sm font-medium text-gray-500 dark:text-gray-400">{{
                    calculatePercentage(count).toFixed(1)
                    }}%</span>
            </div>
        </div>
    </div>
</template>

