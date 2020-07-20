<template >
  <!--  -->
  <div class="text-light hide-show bg-secondary input-round-1 shadow p-2">
    <span>
      <router-link
        :to="{ name: 'vault', params: { id: vaultData.id,name:vaultData.name,description:vaultData.description }}"
      >
        <h4 class="text-primary d-inline">{{vaultData.name}}</h4>
      </router-link>
    </span>
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
  methods: {}
};
</script>

<style>
</style>