import { createWebHistory, createRouter } from "vue-router";
import LoginPage from "../views/Auth/LoginPage.vue";
import RegisterPage from "@/views/Auth/RegisterPage.vue";
import UserProfilePage from "@/views/Account/UserProfilePage.vue";
import ChangePasswordPage from "@/views/Account/ChangePasswordPage.vue";
import HomePage from "../views/Dashboard/HomePage.vue";
import ServicePage from "@/views/Service/ServicePage.vue";
import ServiceDetailPage from "@/views/Service/ServiceDetailPage.vue";
import StaffPage from "@/views/Staff/StaffPage.vue";
import StaffDetailPage from "@/views/Staff/StaffDetailPage.vue";
import UserRecordPage from "@/views/Account/UserRecordPage.vue";
import PaymentPage from "@/views/Account/PaymentPage.vue";
import SubscriptionPage from "@/views/Account/SubscriptionPage.vue";
import SubscriptionDetailPage from "@/views/Account/SubscriptionDetailPage.vue";
import GoogleLogin from "@/components/Auth/GoogleLogin.vue";
import AppointmentDetailPage from "@/views/Account/AppointmentDetailPage.vue";
import PaymentResultPage from "@/views/Service/PaymentResultPage.vue";
import ContactPage from "@/views/Dashboard/ContactPage.vue";
const routes = [
{
    path: "/",
    name: "Home",
    component: HomePage,
},
{
    path: "/contact",
    name: "Contact",
    component: ContactPage,
},
{
    path: "/google-signin",
    name: "Google Login",
    component: GoogleLogin,
},
{
    path: "/payment-result",
    name: "PaymentResult",
    component: PaymentResultPage,
},
{
    path: "/profile",
    name: "UserProfile",
    component: UserProfilePage,
},
{
    path: "/subscription",
    name: "Subscription",
    component: SubscriptionPage,
},
{
    path: "/subscription/:id",
    name: "SubscriptionDetail",
    component: SubscriptionDetailPage,
},
{
    path: "/appointment/:id",
    name: "AppointmentDetail",
    component: AppointmentDetailPage,
},
{
    path: "/payment",
    name: "Payment",
    component: PaymentPage,
},
{
    path: "/record",
    name: "UserRecord",
    component: UserRecordPage,
},
{
    path: "/change-password",
    name: "ChangePassword",
    component: ChangePasswordPage,
},
{
    path: "/service",
    name: "Service",
    component: ServicePage,
},
{
    path: "/service/:id",
    name: "ServiceDetail",
    component: ServiceDetailPage,
},
{
    path: "/staff",
    name: "Staff",
    component: StaffPage,
},
{
    path: "/staff/:id",
    name: "StaffDetail",
    component: StaffDetailPage,
},
{
    path: "/login",
    name: "Login",
    component: LoginPage,
},
{
    path: "/register",
    name: "Register",
    component: RegisterPage,
},
];

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes,
});
export default router;