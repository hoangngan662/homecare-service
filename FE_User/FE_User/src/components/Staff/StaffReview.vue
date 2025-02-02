<template>
    <section v-if="rating.appointmentReviews" class="bg-white antialiased dark:bg-gray-900">
        <div class="mx-auto max-w-screen-xl">
            <div class="flex items-center gap-2">
                <h2 class="text-2xl font-semibold text-gray-900 dark:text-white">Đánh giá nhân viên</h2>
                <div class="flex items-center">
                    <!-- Hiển thị các ngôi sao -->
                    <template v-for="star in 5">
                        <svg v-if="star <= Math.floor(rating.avgStar)" class="w-4 h-4 text-yellow-300 me-1"
                            aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor"
                            viewBox="0 0 22 20" :key="`full-${star}`">
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
                        rating.avgStar.toFixed(2) }}
                    </p>
                    <p class="ms-1 text-sm font-medium text-gray-500 dark:text-gray-400">/</p>
                    <p class="ms-1 text-sm font-medium text-gray-500 dark:text-gray-400">5</p>
                </div>
                <p class="text-sm font-medium text-gray-500 dark:text-gray-800"> - {{ rating.totalReviews
                    }} đánh giá</p>
            </div>
            <div v-for="(count, index) in rating.starCount.slice().reverse()" :key="index"
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

            <div class="mt-2 divide-y divide-gray-200 dark:divide-gray-700">
                <div class="gap-8 pb-2 sm:flex sm:items-start" v-for="review in rating.appointmentReviews"
                    :key="review.id">
                    <div class="shrink-0 space-y-2">
                        <!-- Render rating stars dynamically -->
                        <div class="flex items-center gap-0.5">
                            <template v-for="star in 5">
                                <svg v-if="star <= Math.floor(review.staffRating)" class="h-4 w-4 text-yellow-300"
                                    aria-hidden="true" xmlns="http://www.w3.org/2000/svg" width="24" height="24"
                                    fill="currentColor" viewBox="0 0 24 24">
                                    <path
                                        d="M13.849 4.22c-.684-1.626-3.014-1.626-3.698 0L8.397 8.387l-4.552.361c-1.775.14-2.495 2.331-1.142 3.477l3.468 2.937-1.06 4.392c-.413 1.713 1.472 3.067 2.992 2.149L12 19.35l3.897 2.354c1.52.918 3.405-.436 2.992-2.15l-1.06-4.39 3.468-2.938c1.353-1.146.633-3.336-1.142-3.477l-4.552-.36-1.754-4.17Z" />
                                </svg>
                                <svg v-else class="h-4 w-4 text-gray-300" aria-hidden="true"
                                    xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor"
                                    viewBox="0 0 24 24">
                                    <path
                                        d="M13.849 4.22c-.684-1.626-3.014-1.626-3.698 0L8.397 8.387l-4.552.361c-1.775.14-2.495 2.331-1.142 3.477l3.468 2.937-1.06 4.392c-.413 1.713 1.472 3.067 2.992 2.149L12 19.35l3.897 2.354c1.52.918 3.405-.436 2.992-2.15l-1.06-4.39 3.468-2.938c1.353-1.146.633-3.336-1.142-3.477l-4.552-.36-1.754-4.17Z" />
                                </svg>
                            </template>
                        </div>

                        <!-- Review author and date -->
                        <div class="space-y-0.5">
                            <p class="text-base font-semibold text-gray-900 dark:text-white">Khách hàng ẩn danh
                            </p>
                            <p class="text-sm font-normal text-gray-500 dark:text-gray-400">{{
                                formatDate(review.reviewDate) }}</p>
                        </div>
                    </div>

                    <!-- Review content -->
                    <div class="mt-2 min-w-0 flex-1 space-y-4 sm:mt-0">
                        <p class="text-base font-normal text-gray-500 dark:text-gray-400 mt-2">{{ review.staffComment }}</p>
                    </div>
                </div>
            </div>
        </div>
    </section>
</template>

<script>
export default{
    name: "StaffReview",
    data() {
        return {
            rating:{},
            visibleReviewsCount: 4,
        };
    },
    mounted() {
        this.fetchRating();
    },
    methods: {
        async fetchRating() {
            const staffId = this.$route.params.id;           
            try {
                const response = await fetch(`https://localhost:7072/api/appointment/reviews/${staffId}`);
                if (response.ok) {
                    const data = await response.json();
                    this.rating = data;
                    console.log(this.rating);                    
                } else {
                    this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
                    this.$router.push('/staff');
                }
            } catch (error) {
                this.showErrorToast("Đã xảy ra lỗi. Vui lòng thử lại.");
                this.$router.push('/staff');
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
        formatDate(dateString) {
            const date = new Date(dateString);
            return date.toLocaleDateString('vi-VN', { day: '2-digit', month: '2-digit', year: 'numeric' });
        },
        calculatePercentage(count) {
            return this.rating.totalReviews > 0 ? (count / this.rating.totalReviews) * 100 : 0;
        },
    }
}
</script>