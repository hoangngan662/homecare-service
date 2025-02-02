import { createWebHistory, createRouter } from "vue-router";
import Patient from "../views/User/Patient.vue";
import Staff from "../views/User/Staff.vue";
import LoginPage from "../views/Auth/LoginPage.vue";
import AddPatientPage from "../views/User/AddPatientPage.vue";
import AddStaffPage from "@/views/User/AddStaffPage.vue";
import PatientDetailPage from "@/views/User/PatientDetailPage.vue";
import StaffDetailPage from "@/views/User/StaffDetailPage.vue";
import ServiceTypePage from "@/views/Service/ServiceTypePage.vue";
import AddServiceTypePage from "@/views/Service/AddServiceTypePage.vue";
import ServiceTypeDetailPage from "@/views/Service/ServiceTypeDetailPage.vue";
import ServicePackagePage from "@/views/Service/ServicePackagePage.vue";
import SubscriptionPage from "@/views/Subscription/SubscriptionPage.vue";
import AppointmentPage from "@/views/Appointment/AppointmentPage.vue";
import AddSubscriptionPage from "@/views/Subscription/AddSubscriptionPage.vue";
import SubscriptionDetailPage from "@/views/Subscription/SubscriptionDetailPage.vue";
import AppointmentDetailPage from "@/views/Appointment/AppointmentDetailPage.vue";
import UserProfilePage from "@/views/Account/UserProfilePage.vue";
import ChangePasswordPage from "@/views/Account/ChangePasswordPage.vue";
import HomePage from "../views/Dashboard/HomePage.vue";
import ContactPage from "@/views/Contact/ContactPage.vue";
import PaymentPage from "@/views/Contact/PaymentPage.vue";
import SchedulePage from "@/views/Appointment/SchedulePage.vue";
import StatisticPage from "@/views/Dashboard/StatisticPage.vue";
import ReviewPage from "@/views/Appointment/ReviewPage.vue";
import Chat from "@/components/Contact/Chat.vue";
import ReportPage from "@/views/Dashboard/ReportPage.vue";
const routes = [
{
    path: "/",
    name: "Home",
    component: HomePage,
},
{
    path: "/chat",
    name: "Chat",
    component: Chat,
},
{
    path: "/",
    name: "Home",
    component: HomePage,
},
{
    path: "/report",
    name: "Report",
    component: ReportPage,
},
{
    path: "/statistic",
    name: "Statistic",
    component: StatisticPage,
},
{
    path: "/contact",
    name: "Contact",
    component: ContactPage,
},
{
    path: "/payment",
    name: "Payment",
    component: PaymentPage,
},
{
    path: "/profile",
    name: "UserProfile",
    component: UserProfilePage,
},
{
    path: "/change-password",
    name: "ChangePassword",
    component: ChangePasswordPage,
},
{
    path: "/service-type",
    name: "ServiceType",
    component: ServiceTypePage,
},
{
    path: "/service-type/add",
    name: "AddServiceType",
    component: AddServiceTypePage,
},
{
    path: "/service-type/:id",
    name: "ServiceTypeDetail",
    component: ServiceTypeDetailPage,
},
{
    path: "/service-package",
    name: "ServicePackagePage",
    component: ServicePackagePage,
},
{
    path: "/service-package/add",
    name: "AddServicePackage",
    component: ServicePackagePage,
},
{
    path: "/subscription",
    name: "Subscription",
    component: SubscriptionPage,
},
{
    path: "/subscription/add",
    name: "AddSubscription",
    component: AddSubscriptionPage,
},
{
    path: "/subscription/:id",
    name: "SubscriptionDetail",
    component: SubscriptionDetailPage,
},
{
    path: "/schedule",
    name: "Schedule",
    component: SchedulePage,
},
{
    path: "/review",
    name: "Review",
    component: ReviewPage,
},
{
    path: "/appointment",
    name: "Appointment",
    component: AppointmentPage,
},
{
    path: "/appointment/:id",
    name: "AppointmentDetail",
    component: AppointmentDetailPage,
},
{
    path: "/patient",
    name: "Patient",
    component: Patient,
},
{
    path: "/patient/add",
    name: "AddPatient",
    component: AddPatientPage,
},
{
    path: "/patient/:id",
    name: "PatientDetail",
    component: PatientDetailPage,
},
{
    path: "/staff",
    name: "Staff",
    component: Staff,
},
{
    path: "/staff/add",
    name: "AddStaff",
    component: AddStaffPage,
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
];

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes,
});
export default router;