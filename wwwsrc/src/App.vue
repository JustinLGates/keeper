<template>
  <div id="app">
    <navbar />
    <router-view />
    <keepForm />
    <vaultForm />
    <optionsForm />
    <keepDetailsModal />
    <keepEditModal />
  </div>
</template>

<script>
import Navbar from "@/components/navbar";
import { onAuth } from "@bcwdev/auth0-vue";
import keepForm from "./components/Modals/KeepForm.vue";
import vaultForm from "./components/Modals/VaultForm.vue";
import optionsForm from "./components/Modals/OptionsForm.vue";
import keepDetailsModal from "./components/Modals/KeepDetails.vue";
import keepEditModal from "./components/Modals/KeepEditModal.vue";
export default {
  name: "App",
  async beforeCreate() {
    await onAuth();
    this.$store.dispatch("setBearer", this.$auth.bearer);
  },
  components: {
    Navbar,
    keepForm,
    vaultForm,
    optionsForm,
    keepDetailsModal,
    keepEditModal
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
.input-round-top {
  border-top-left-radius: 20px;
  border-top-right-radius: 20px;
}
.input-round {
  border-radius: 20px;
  border: 3px inset rgb(109, 109, 109);
  outline: none !important;
}
.input-round-1 {
  border-radius: 20px;
}
.input-round-2 {
  border-radius: 20px;
  box-shadow: 2px 2px 2px rgb(26, 26, 26);
  border: 3px outset rgb(31, 31, 31);
  outline: none !important;
}

// this section is for the toggle switch component
//NOTE MAY HAVE TO CHANGE COLORS........ TO MATCH COLOR THEME AFTER OFICIAL COLORS ARE PICKED
.switch {
  position: relative;
  display: inline-block;
  width: 60px;
  height: 34px;
  border-radius: 20px;
  box-shadow: 2px 2px 2px rgb(26, 26, 26);
  border: 3px outset rgb(31, 31, 31);
  outline: none !important;
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
  background-color: #444444;
  -webkit-transition: 0.4s;
  transition: 0.4s;
}
.slider:before {
  position: absolute;
  content: "";
  height: 23px;
  width: 23px;
  top: 3px;
  left: 2px;
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
.profile-img-large {
  height: 8rem;
  width: 8rem;
  border-radius: 50%;
}
.mouse-show {
  opacity: 0;
}
/* may need to adjust this to .. */
.hide-show:hover .mouse-show {
  opacity: 1;
}
</style>
