<template>
  <div id="app">
    <navbar />
    <router-view />
    <keepform />
  </div>
</template>

<script>
import Navbar from "@/components/navbar";
import { onAuth } from "@bcwdev/auth0-vue";
import keepform from "./components/KeepForm.vue";
export default {
  name: "App",
  async beforeCreate() {
    await onAuth();
    this.$store.dispatch("setBearer", this.$auth.bearer);
  },
  components: {
    Navbar,
    keepform
  }
};
</script>

<style lang="scss">
@import "./assets/_variables.scss";
@import "bootstrap";
@import "./assets/_overrides.scss";

.action:hover {
  cursor: pointer;
  opacity: 0.5;
}
.circle {
  border-radius: 50%;
}
.proflieImg {
  width: 3rem;
  height: 3rem;
}
.input-round {
  border-radius: 20px;
  outline: none !important;
}

// this section is for the toggle switch component
//NOTE MAY HAVE TO CHANGE COLORS........ TO MATCH COLOR THEME AFTER OFICIAL COLORS ARE PICKED
.switch {
  position: relative;
  display: inline-block;
  width: 60px;
  height: 34px;
}
.switch input {
  opacity: 0;
  width: 0;
  height: 0;
}
.slider {
  position: absolute;
  cursor: pointer;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  //2a2a2a
  background-color: #b82d2d;
  -webkit-transition: 0.4s;
  transition: 0.4s;
}
.slider:before {
  position: absolute;
  content: "";
  height: 26px;
  width: 26px;
  left: 4px;
  bottom: 4px;
  background-color: #dadada;
  -webkit-transition: 0.4s;
  transition: 0.4s;
}
input:checked + .slider {
  background-color: rgb(48, 163, 48);
}
// $success: rgb(48, 163, 48);

input:focus + .slider {
  box-shadow: 0 0 1px rgba(0, 0, 0, 0);
}
input:checked + .slider:before {
  -webkit-transform: translateX(26px);
  -ms-transform: translateX(26px);
  transform: translateX(26px);
}
.slider.round {
  border-radius: 34px;
}
.slider.round:before {
  border-radius: 50%;
}
//End of switch component
</style>
