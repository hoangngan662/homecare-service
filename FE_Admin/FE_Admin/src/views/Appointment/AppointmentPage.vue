<template>
    <!-- <Appointment/> -->
     <AppointmentShift/>
</template>
<script>
import Appointment from '@/components/Appointment/Appointment.vue';
import AppointmentShift from '@/components/Appointment/AppointmentShift.vue';

export default{
    name: 'AppointmentPage',
    components: {
        Appointment,
        AppointmentShift
    }
}
</script>