<template>
    chat
</template>
<script>
export default{
    methods:{

    },
    mounted(){
        (function(d, m){
            var kommunicateSettings = 
                {"appId":"1317ebac843b93c9e2659f7a167f382d5","popupWidget":true,"automaticChatOpenOnNavigation":true};
            var s = document.createElement("script"); s.type = "text/javascript"; s.async = true;
            s.src = "https://widget.kommunicate.io/v2/kommunicate.app";
            var h = document.getElementsByTagName("head")[0]; h.appendChild(s);
            window.kommunicate = m; m._globals = kommunicateSettings;
        })(document, window.kommunicate || {});
    }
}
</script>