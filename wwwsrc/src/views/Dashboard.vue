<template>
  <div class="dashboard container-fluid">
    <div class="row">
      <div class="col-12 col-md-12 text-center p-1">
        <h3 class="p-1">Welcome back username....</h3>
        <img class="profile-img-large" src="https://placehold.it/150" alt />
      </div>
      <div class="col-12 text-center">
        <button class="text-light btn btn-info btn-outline-dark m-1 my-2">Vaults</button>
        <button class="text-light btn btn-info btn-outline-dark m-1 my-2">Keeps</button>
      </div>
    </div>

    <div class="row">
      <!--  TODO MAKE A METHOD TO HANDLE Details -->
      <div @click="viewDetails" class="col-12 col-md-4 w-100 p-1 px-sm-3 hide-show">
        <div class="card bg-secondary w-100 text-light p-1 px-sm-2 input-round-1">
          <div class="d-flex justify-content-between align-items-center p-1">
            <span>
              <h4 class="text-primary">This is the title</h4>
            </span>
            <span class="input-round-2 mouse-show">
              <!--  TODO MAKE A METHOD TO HANDLE ADDING KEEP TO A USERS VAULT -->
              <button
                @click="CreateKeepReferance"
                class="btn btn-info input-round-1 text-light"
              >Keeper</button>
            </span>
          </div>
          <p class="px-2 mouse-show">Description</p>
        </div>
      </div>

      <div class="col-12 col-md-4 w-100 p-1 px-sm-3 hide-show">
        <div class="card bg-secondary w-100 text-light p-1 px-sm-2 input-round-1">
          <div class="d-flex justify-content-between align-items-center p-1">
            <span>
              <h4 class="text-primary">asd</h4>
            </span>
            <span class="input-round-2 mouse-show">
              <button class="btn btn-info input-round-1 text-light">view</button>
            </span>
          </div>
          <p class="px-2">as</p>
        </div>
      </div>
      <div class="col-12 col-md-4 w-100 p-1 px-sm-3 hide-show">
        <div class="card bg-secondary w-100 text-light p-1 px-sm-2 input-round-1">
          <div class="d-flex justify-content-between align-items-center p-1">
            <span>
              <h4 class="text-primary">asd</h4>
            </span>
            <span class="input-round-2 mouse-show">
              <button class="btn btn-info input-round-1 text-light">view</button>
            </span>
          </div>
          <p class="px-2">as</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  mounted() {
    this.$store.dispatch("getUserVaults");
  },
  computed: {},
  methods: {
    CreateKeepReferance() {
      event.stopPropagation();
      console.log("keeping......");
    },
    viewDetails() {
      console.log("taking to details......");
    }
  }
};
</script>

<style>
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
