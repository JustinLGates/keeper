<template>
  <div class="card">
    <div class="hide-show">
      <div class="card bg-secondary w-100 text-light p-1 px-sm-2 input-round-1">
        <div class="d-flex justify-content-between align-items-center p-1">
          <span>
            <h4 class="text-primary">{{vaultData.Name}}</h4>
          </span>
          <span class="input-round-2 mouse-show">
            <router-link
              class="btn btn-info input-round-1 text-light"
              :to="{ name: 'vault', params: { id: vaultData.Id }}"
            >View</router-link>
            <!-- <a @click="viewDetails" class="btn btn-info input-round-1 text-light">View Vault</a> -->
          </span>
        </div>
        <p class="px-2 mouse-show">{{vaultData.Description}}</p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Vault",
  data() {
    return {};
  },
  props: ["vaultData"],
  methods: {}
};
</script>

<style>
</style>