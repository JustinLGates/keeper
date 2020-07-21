<template >
  <div class="text-light hide-show bg-secondary input-round-1 shadow p-2">
    <div class="d-flex justify-content-between">
      <span>
        <router-link :to="{ name: 'vault', params: { id: vaultData.id,name:vaultData.name }}">
          <h4 class="text-primary d-inline">{{vaultData.name}}</h4>
        </router-link>
      </span>
      <button
        @click="deleteVault(vaultData.id)"
        class="btn btn-danger mouse-show text-light input-round-1"
      >delete</button>
    </div>
    <p class="px-2 mouse-show">{{vaultData.description}}</p>
  </div>
</template>

<script>
export default {
  name: "Vault",
  mounted() {},
  data() {
    return {};
  },
  props: ["vaultData"],
  methods: {
    deleteVault(id) {
      this.$store.dispatch("deleteVault", id);
      event.stopPropagation();
    }
  }
};
</script>

<style>
</style>