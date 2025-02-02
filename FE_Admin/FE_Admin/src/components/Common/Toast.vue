<template>
    <div v-if="isVisible" class="fixed top-5 right-5 w-full max-w-xs p-4 bg-white rounded-lg shadow-lg dark:bg-gray-800 z-[9999]" role="alert">
        <div class="flex items-center">
            <div class="inline-flex items-center justify-center flex-shrink-0 w-8 h-8 rounded-lg" :class="success ? 'text-green-500 bg-green-100' : 'text-red-500 bg-red-100'">
                <svg class="w-5 h-5" :fill="success ? 'currentColor' : 'red'" viewBox="0 0 20 20">
                    <path v-if="success" d="M10 .5a9.5 9.5 0 1 0 9.5 9.5A9.51 9.51 0 0 0 10 .5Zm3.707 8.207-4 4a1 1 0 0 1-1.414 0l-2-2a1 1 0 0 1 1.414-1.414L9 10.586l3.293-3.293a1 1 0 0 1 1.414 1.414Z" />
                    <path v-else d="M10 .5a9.5 9.5 0 1 0 9.5 9.5A9.51 9.51 0 0 0 10 .5Zm3.707 11.793a1 1 0 1 1-1.414 1.414L10 11.414l-2.293 2.293a1 1 0 0 1-1.414-1.414L8.586 10 6.293 7.707a1 1 0 0 1 1.414-1.414L10 8.586l2.293-2.293a1 1 0 0 1 1.414 1.414L11.414 10l2.293 2.293Z" />
                </svg>
            </div>
            <div class="ml-3 text-sm font-normal">
                <p>{{ message }}</p>
            </div>
            <button type="button" @click="$emit('close')" class="ml-auto p-1 rounded-lg hover:bg-gray-200 dark:hover:bg-gray-700" aria-label="Close">
                <svg class="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12" />
                </svg>
            </button>
        </div>
    </div>
</template>

<script>
export default {
    name: 'Toast',
    props: {
        message: {
            type: String,
            required: true,
        },
        isVisible: {
            type: Boolean,
            required: true,
        },
    },
    computed: {
        success() {
            return this.message.toLowerCase().includes("thành công");
        }
    }
}
</script>

<style scoped>
/* Toast sẽ luôn hiển thị ở vị trí cố định, kể cả khi cuộn trang */
</style>
