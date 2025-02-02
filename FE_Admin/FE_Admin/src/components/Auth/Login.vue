<script>
export default {
    name: "Login",
    data() {
        return {
            model: {
                email: '',
                password: ''
            },
            role: '',
            isHandle: false,
        };
    },
    mounted() {
        this.dailyUpdate();
    },
    methods: {
        async login() {
            try {
                this.isHandle = true;
                const response = await fetch('https://localhost:7072/api/auth/login', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(this.model),
                });

                if (response.ok) {
                    const data = await response.json();
                    console.log(data);

                    const { token, username } = data;
                    const decodedToken = this.decodeJwt(token);
                    this.role = decodedToken.role;
                    console.log(this.role);


                    if (this.role == "Patient") {
                        alert('Tài khoản không hợp lệ.');
                    }
                    else {
                        alert('Đăng nhập thành công.');
                        localStorage.setItem('fullnameStaff', decodedToken.fullname);
                        localStorage.setItem('emailStaff', decodedToken.sub);
                        localStorage.setItem('roleStaff', decodedToken.role);
                        localStorage.setItem('idStaff', decodedToken.jti);
                        this.$router.push('/').then(() => {
                            window.location.reload();
                        });
                    }

                } else {
                    this.isHandle = false;
                    alert('Đăng nhập thất bại.');

                }
            } catch (error) {
                console.error('Error:', error);
                alert('Đã xảy ra lỗi. Hãy thử lại.');
            }
        },
        decodeJwt(token) {
            const base64Url = token.split('.')[1];
            const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
            const jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
                return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
            }).join(''));

            return JSON.parse(jsonPayload);
        },
        async dailyUpdate(){
            try {
                this.isHandle = true;
                const response = await fetch('https://localhost:7072/api/appointment/daily', {
                    method: 'PUT',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                });

                if (response.ok) {                    

                } else {
                    alert('Đã xảy ra lỗi. Hãy thử lại.');
                }
            } catch (error) {
                console.error('Error:', error);
                alert('Đã xảy ra lỗi. Hãy thử lại.');
            }
            finally{
                this.isHandle = false;
            }
        }
    },
}
</script>

<template>
    <div v-if="isHandle" class="fixed inset-0 flex items-center justify-center bg-black bg-opacity-50 z-50">
        <div role="status">
            <svg aria-hidden="true" class="w-8 h-8 text-gray-200 animate-spin dark:text-gray-600 fill-blue-600"
                viewBox="0 0 100 101" fill="none" xmlns="http://www.w3.org/2000/svg">
                <path
                    d="M100 50.5908C100 78.2051 77.6142 100.591 50 100.591C22.3858 100.591 0 78.2051 0 50.5908C0 22.9766 22.3858 0.59082 50 0.59082C77.6142 0.59082 100 22.9766 100 50.5908ZM9.08144 50.5908C9.08144 73.1895 27.4013 91.5094 50 91.5094C72.5987 91.5094 90.9186 73.1895 90.9186 50.5908C90.9186 27.9921 72.5987 9.67226 50 9.67226C27.4013 9.67226 9.08144 27.9921 9.08144 50.5908Z"
                    fill="currentColor" />
                <path
                    d="M93.9676 39.0409C96.393 38.4038 97.8624 35.9116 97.0079 33.5539C95.2932 28.8227 92.871 24.3692 89.8167 20.348C85.8452 15.1192 80.8826 10.7238 75.2124 7.41289C69.5422 4.10194 63.2754 1.94025 56.7698 1.05124C51.7666 0.367541 46.6976 0.446843 41.7345 1.27873C39.2613 1.69328 37.813 4.19778 38.4501 6.62326C39.0873 9.04874 41.5694 10.4717 44.0505 10.1071C47.8511 9.54855 51.7191 9.52689 55.5402 10.0491C60.8642 10.7766 65.9928 12.5457 70.6331 15.2552C75.2735 17.9648 79.3347 21.5619 82.5849 25.841C84.9175 28.9121 86.7997 32.2913 88.1811 35.8758C89.083 38.2158 91.5421 39.6781 93.9676 39.0409Z"
                    fill="currentFill" />
            </svg>
            <span class="sr-only">Loading...</span>
        </div>
    </div>

    <div class="flex items-center justify-center h-screen px-6 bg-gray-200 dark:bg-gray-600">
        <div class="w-full max-w-sm p-6 bg-white rounded-md shadow-md dark:bg-gray-800">
            <div class="flex items-center justify-center">
                <img src="/home.png" class="h-10 me-3" alt="FlowBite Logo" />
                <span class="text-2xl font-semibold text-gray-700 dark:text-white">Admin Login</span>
            </div>
            <form class="mt-4" @submit.prevent="login">
                <div class="mt-4">
                    <label for="email"
                        class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Email
                        <span class="text-red-600 text-sm">*</span>
                    </label>
                    <input type="email" id="email" v-model="model.email"
                        class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                        placeholder="nguyena@example.com" required />
                </div>

                <div class="mt-4">
                    <label for="password" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Mật
                        khẩu
                        <span class="text-red-600 text-sm">*</span>
                    </label>
                    <input type="password" id="password" v-model="model.password"
                        class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                        placeholder="•••••••••" required />
                </div>

                <div class="mt-6">
                    <button type="submit"
                        class="w-full text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:ring-blue-300 font-medium rounded-lg text-sm px-5 py-2.5 me-2 mb-2 dark:bg-blue-600 dark:hover:bg-blue-700 focus:outline-none dark:focus:ring-blue-800">
                        ĐĂNG NHẬP
                    </button>
                </div>
            </form>
        </div>
    </div>
</template>


<style>
.divider {
    display: flex;
    align-items: center;
    text-align: center;
}

.divider::before,
.divider::after {
    content: '';
    flex: 1;
    border-bottom: 1px solid #d1d5db;
    /* light gray */
}

.divider::before {
    margin-right: .5em;
}

.divider::after {
    margin-left: .5em;
}

.dark .divider::before,
.dark .divider::after {
    border-color: #4b5563;
    /* dark gray for dark mode */
}
</style>