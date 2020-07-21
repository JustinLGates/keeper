<template>
  <div class="dashboard container-fluid">
    <profileHeader />
    <div class="row">
      <div class="col-12 text-center">
        <button
          v-if="!toggle"
          @click="toggleView"
          class="text-light btn btn-info btn-outline-dark m-1 my-2"
        >Vaults</button>
        <button
          v-else
          @click="toggleView"
          class="text-light btn btn-info btn-outline-dark m-1 my-2"
        >Keeps</button>
      </div>
    </div>
    <vaultDisplay v-if="this.toggle" />
    <keepDisplay v-else />
  </div>
</template>

<script>
import profileHeader from "../components/ProfileHeader.vue";
import vaultDisplay from "../components/VaultDisplay.vue";
import keepDisplay from "../components/KeepDisplay.vue";
export default {
  name: "dashboard",
  data() {
    return {
      toggle: true
    };
  },
  computed: {},
  components: {
    profileHeader,
    vaultDisplay,
    keepDisplay
  },
  methods: {
    toggleView() {
      this.toggle = !this.toggle;
    }
  }
};
</script>

<style>
</style>
