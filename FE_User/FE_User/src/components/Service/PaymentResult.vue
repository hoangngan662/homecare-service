<template>
    <div v-if="success" class="relative flex flex-col items-center justify-center p-8 overflow-x-auto shadow-md sm:rounded-lg">

        <svg class="w-32 h-32 text-green-500 dark:text-white mb-4" aria-hidden="true" xmlns="http://www.w3.org/2000/svg"
            fill="currentColor" viewBox="0 0 24 24">
            <path fill-rule="evenodd"
                d="M2 12C2 6.477 6.477 2 12 2s10 4.477 10 10-4.477 10-10 10S2 17.523 2 12Zm13.707-1.293a1 1 0 0 0-1.414-1.414L11 12.586l-1.793-1.793a1 1 0 0 0-1.414 1.414l2.5 2.5a1 1 0 0 0 1.414 0l4-4Z"
                clip-rule="evenodd" />
        </svg>

        <span class="text-2xl font-semibold text-center text-green-600 dark:text-white mb-4">
            Thanh toán dịch vụ thành công!
        </span>
        <router-link to="/subscription">
            Xem chi tiết
        </router-link>
    </div>

    <div v-else class="relative flex flex-col items-center justify-center p-8 overflow-x-auto shadow-md sm:rounded-lg">

        <svg class="w-32 h-32 text-red-600 dark:text-white" aria-hidden="true" xmlns="http://www.w3.org/2000/svg"
            fill="currentColor" viewBox="0 0 24 24">
            <path fill-rule="evenodd"
                d="M2 12C2 6.477 6.477 2 12 2s10 4.477 10 10-4.477 10-10 10S2 17.523 2 12Zm7.707-3.707a1 1 0 0 0-1.414 1.414L10.586 12l-2.293 2.293a1 1 0 1 0 1.414 1.414L12 13.414l2.293 2.293a1 1 0 0 0 1.414-1.414L13.414 12l2.293-2.293a1 1 0 0 0-1.414-1.414L12 10.586 9.707 8.293Z"
                clip-rule="evenodd" />
        </svg>


        <span class="text-2xl font-semibold text-center text-red-600 dark:text-white mb-4">
            Thanh toán dịch vụ thất bại!
        </span>
    </div>

</template>
<script>
export default {
    name: 'PaymentResult',
    data() {
        return {
            vnPaymentResponse: {
                success: false,
                paymentMethod: '',
                orderDescription: '',
                orderId: '',
                transactionId: '',
                token: '',
                vnPayResponseCode: '',
                paymentId: ''
            },
            success: false,
        };
    },
    mounted() {
        const urlParams = new URLSearchParams(window.location.search);
        this.vnPaymentResponse.orderId = urlParams.get("vnp_TxnRef");
        this.vnPaymentResponse.transactionId = urlParams.get("vnp_TransactionNo");
        this.vnPaymentResponse.amount = urlParams.get("vnp_Amount");
        this.vnPaymentResponse.paymentId = urlParams.get("vnp_OrderInfo");
        this.vnPaymentResponse.bankCode = urlParams.get("vnp_BankCode");
        this.vnPaymentResponse.orderDescription = urlParams.get("vnp_OrderInfo");
        this.vnPaymentResponse.payDate = urlParams.get("vnp_PayDate");
        this.vnPaymentResponse.vnPayResponseCode = urlParams.get("vnp_ResponseCode");
        if(this.vnPaymentResponse.vnPayResponseCode == "00"){
            try{
                this.sendPaymentResponse();
                this.success = true;
            }
            catch(error){
                this.success = false;
            }
        }
        else{
            this.success = false;
        }        
    },
    methods: {
        async sendPaymentResponse() {
            try {
                const response = await fetch('https://localhost:7072/api/payment/return', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(this.vnPaymentResponse)
                });

                if (response.ok) {
                    console.log('Payment data sent successfully');
                } else {
                    console.error('Failed to send payment data:', response.statusText);
                }
            } catch (error) {
                console.error('Error sending payment data:', error);
            }
        }
    }
}
</script>