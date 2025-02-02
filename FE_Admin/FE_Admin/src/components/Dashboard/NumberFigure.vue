<script>
import axios from 'axios';
export default {
    name: "NumberFigure",
    data() {
        return {
            statsData: {
                totalPatients: '',
                totalStaffs: '',
                totalServices: '',
                totalServicePackages: '',
                totalSubscription: '',
                totalAppointments: '',
                totalRevenue: ''
            },
        };
    },
    mounted() {
        this.fetchData();
    },
    methods: {
        async fetchData() {
            try {
                const response = await axios.get('https://localhost:7072/api/stats');
                this.statsData = response.data;
            } catch (error) {
                console.error("There was an error fetching the Service Types:", error);
            }
        },
        formatPrice(value) {
            return new Intl.NumberFormat('vi-VN').format(value);
        },
    },
}
</script>

<template>
    <div class="grid grid-cols-1 md:grid-cols-3 gap-4 mb-4">
        <div
        class="flex items-center max-w-xs p-6 bg-red-500 border border-red-200 rounded-lg shadow-lg hover:bg-red-600 dark:bg-red-700 dark:border-red-600 dark:hover:bg-red-800">
            <div class="flex-shrink-0">
                <svg class="w-12 h-12 text-white" aria-hidden="true"
                    xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 24 24">
                    <path fill-rule="evenodd"
                        d="M12 6a3.5 3.5 0 1 0 0 7 3.5 3.5 0 0 0 0-7Zm-1.5 8a4 4 0 0 0-4 4 2 2 0 0 0 2 2h7a2 2 0 0 0 2-2 4 4 0 0 0-4-4h-3Zm6.82-3.096a5.51 5.51 0 0 0-2.797-6.293 3.5 3.5 0 1 1 2.796 6.292ZM19.5 18h.5a2 2 0 0 0 2-2 4 4 0 0 0-4-4h-1.1a5.503 5.503 0 0 1-.471.762A5.998 5.998 0 0 1 19.5 18ZM4 7.5a3.5 3.5 0 0 1 5.477-2.889 5.5 5.5 0 0 0-2.796 6.293A3.501 3.501 0 0 1 4 7.5ZM7.1 12H6a4 4 0 0 0-4 4 2 2 0 0 0 2 2h.5a5.998 5.998 0 0 1 3.071-5.238A5.505 5.505 0 0 1 7.1 12Z"
                        clip-rule="evenodd" />
                </svg>
            </div>
            <div class="ml-4">
                <h5 class="mb-2 font-bold text-xl tracking-tight text-white">Khách hàng</h5>
                <p class="text-4xl font-bold text-white">{{ this.statsData.totalPatients }}</p>
            </div>
        </div>
        <div
        class="flex items-center max-w-xs p-6 bg-purple-500 border border-purple-200 rounded-lg shadow-lg hover:bg-purple-600 dark:bg-purple-700 dark:border-purple-600 dark:hover:bg-purple-800">
            <div class="flex-shrink-0">
                <svg class="w-12 h-12 text-white" aria-hidden="true"
                    xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 24 24">
                    <path fill-rule="evenodd"
                        d="M17 10v1.126c.367.095.714.24 1.032.428l.796-.797 1.415 1.415-.797.796c.188.318.333.665.428 1.032H21v2h-1.126c-.095.367-.24.714-.428 1.032l.797.796-1.415 1.415-.796-.797a3.979 3.979 0 0 1-1.032.428V20h-2v-1.126a3.977 3.977 0 0 1-1.032-.428l-.796.797-1.415-1.415.797-.796A3.975 3.975 0 0 1 12.126 16H11v-2h1.126c.095-.367.24-.714.428-1.032l-.797-.796 1.415-1.415.796.797A3.977 3.977 0 0 1 15 11.126V10h2Zm.406 3.578.016.016c.354.358.574.85.578 1.392v.028a2 2 0 0 1-3.409 1.406l-.01-.012a2 2 0 0 1 2.826-2.83ZM5 8a4 4 0 1 1 7.938.703 7.029 7.029 0 0 0-3.235 3.235A4 4 0 0 1 5 8Zm4.29 5H7a4 4 0 0 0-4 4v1a2 2 0 0 0 2 2h6.101A6.979 6.979 0 0 1 9 15c0-.695.101-1.366.29-2Z"
                        clip-rule="evenodd" />
                </svg>

            </div>
            <div class="ml-4">
                <h5 class="mb-2 font-bold text-xl tracking-tight text-white">Nhân viên</h5>
                <p class="text-4xl font-bold text-white">{{ this.statsData.totalStaffs }}</p>
            </div>
        </div>
        <div
        class="flex items-center max-w-xs p-6 bg-yellow-400 border border-yellow-200 rounded-lg shadow-lg hover:bg-yellow-500 dark:bg-yellow-600 dark:border-yellow-500 dark:hover:bg-yellow-700">
            <div class="flex-shrink-0">
                <svg xmlns="http://www.w3.org/2000/svg" fill="currentColor"
                    class="bi bi-heart-pulse-fill w-12 h-12 text-white" viewBox="0 0 24 24">
                    <path
                        d="M1.475 9C2.702 10.84 4.779 12.871 8 15c3.221-2.129 5.298-4.16 6.525-6H12a.5.5 0 0 1-.464-.314l-1.457-3.642-1.598 5.593a.5.5 0 0 1-.945.049L5.889 6.568l-1.473 2.21A.5.5 0 0 1 4 9z" />
                    <path
                        d="M.88 8C-2.427 1.68 4.41-2 7.823 1.143q.09.083.176.171a3 3 0 0 1 .176-.17C11.59-2 18.426 1.68 15.12 8h-2.783l-1.874-4.686a.5.5 0 0 0-.945.049L7.921 8.956 6.464 5.314a.5.5 0 0 0-.88-.091L3.732 8z" />
                </svg>
            </div>
            <div class="ml-4">
                <h5 class="mb-2 font-bold text-xl tracking-tight text-white">Dịch vụ</h5>
                <p class="text-4xl font-bold text-white">{{ this.statsData.totalServices }}</p>
            </div>
        </div>
        <div
        class="flex items-center max-w-xs p-6 bg-teal-500 border border-teal-200 rounded-lg shadow-lg hover:bg-teal-600 dark:bg-teal-700 dark:border-teal-600 dark:hover:bg-teal-800">
            <div class="flex-shrink-0">
                <svg xmlns="http://www.w3.org/2000/svg" fill="currentColor"
                    class="bi bi-clipboard2-plus-fill w-12 h-12 text-white" viewBox="0 0 24 24">
                    <path
                        d="M10 .5a.5.5 0 0 0-.5-.5h-3a.5.5 0 0 0-.5.5.5.5 0 0 1-.5.5.5.5 0 0 0-.5.5V2a.5.5 0 0 0 .5.5h5A.5.5 0 0 0 11 2v-.5a.5.5 0 0 0-.5-.5.5.5 0 0 1-.5-.5" />
                    <path
                        d="M4.085 1H3.5A1.5 1.5 0 0 0 2 2.5v12A1.5 1.5 0 0 0 3.5 16h9a1.5 1.5 0 0 0 1.5-1.5v-12A1.5 1.5 0 0 0 12.5 1h-.585q.084.236.085.5V2a1.5 1.5 0 0 1-1.5 1.5h-5A1.5 1.5 0 0 1 4 2v-.5q.001-.264.085-.5M8.5 6.5V8H10a.5.5 0 0 1 0 1H8.5v1.5a.5.5 0 0 1-1 0V9H6a.5.5 0 0 1 0-1h1.5V6.5a.5.5 0 0 1 1 0" />
                </svg>
            </div>
            <div class="ml-4">
                <h5 class="mb-2 font-bold text-xl tracking-tight text-white">Gói dịch vụ</h5>
                <p class="text-4xl font-bold text-white">{{ this.statsData.totalServicePackages }}</p>
            </div>
        </div>
        <div
        class="flex items-center max-w-xs p-6 bg-pink-500 border border-pink-200 rounded-lg shadow-lg hover:bg-pink-600 dark:bg-pink-700 dark:border-pink-600 dark:hover:bg-pink-800">
            <div class="flex-shrink-0">
                <svg xmlns="http://www.w3.org/2000/svg" fill="currentColor"
                    class="bi bi-clipboard2-pulse-fill w-12 h-12 text-white" viewBox="0 0 24 24">
                    <path
                        d="M10 .5a.5.5 0 0 0-.5-.5h-3a.5.5 0 0 0-.5.5.5.5 0 0 1-.5.5.5.5 0 0 0-.5.5V2a.5.5 0 0 0 .5.5h5A.5.5 0 0 0 11 2v-.5a.5.5 0 0 0-.5-.5.5.5 0 0 1-.5-.5" />
                    <path
                        d="M4.085 1H3.5A1.5 1.5 0 0 0 2 2.5v12A1.5 1.5 0 0 0 3.5 16h9a1.5 1.5 0 0 0 1.5-1.5v-12A1.5 1.5 0 0 0 12.5 1h-.585q.084.236.085.5V2a1.5 1.5 0 0 1-1.5 1.5h-5A1.5 1.5 0 0 1 4 2v-.5q.001-.264.085-.5M9.98 5.356 11.372 10h.128a.5.5 0 0 1 0 1H11a.5.5 0 0 1-.479-.356l-.94-3.135-1.092 5.096a.5.5 0 0 1-.968.039L6.383 8.85l-.936 1.873A.5.5 0 0 1 5 11h-.5a.5.5 0 0 1 0-1h.191l1.362-2.724a.5.5 0 0 1 .926.08l.94 3.135 1.092-5.096a.5.5 0 0 1 .968-.039Z" />
                </svg>
            </div>
            <div class="ml-4">
                <h5 class="mb-2 font-bold text-xl tracking-tight text-white">Lượt đăng ký</h5>
                <p class="text-4xl font-bold text-white">{{ this.statsData.totalSubscription }}</p>
            </div>
        </div>
        <div
        class="flex items-center max-w-xs p-6 bg-green-500 border border-green-200 rounded-lg shadow-lg hover:bg-green-600 dark:bg-green-700 dark:border-green-600 dark:hover:bg-green-800">
            <div class="flex-shrink-0">
                <svg class="w-10 h-10 text-white " aria-hidden="true"
                    xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 24 24">
                    <path fill-rule="evenodd"
                        d="M18 5.05h1a2 2 0 0 1 2 2v2H3v-2a2 2 0 0 1 2-2h1v-1a1 1 0 1 1 2 0v1h3v-1a1 1 0 1 1 2 0v1h3v-1a1 1 0 1 1 2 0v1Zm-15 6v8a2 2 0 0 0 2 2h14a2 2 0 0 0 2-2v-8H3ZM11 18a1 1 0 1 0 2 0v-1h1a1 1 0 1 0 0-2h-1v-1a1 1 0 1 0-2 0v1h-1a1 1 0 1 0 0 2h1v1Z"
                        clip-rule="evenodd" />
                </svg>
            </div>
            <div class="ml-4">
                <h5 class="mb-2 font-bold text-xl tracking-tight text-white">Lịch hẹn</h5>
                <p class="text-4xl font-bold text-white">{{ this.statsData.totalAppointments }}</p>
            </div>
        </div>
    </div>
</template>
