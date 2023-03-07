<template>
  <q-page class="q-pa-md">
    <q-card class="q-pa-md q-mt-lg">
      <q-card-section>
        <h2 class="text-h4">Sign In</h2>
        <q-form class="q-mt-md" @submit="handleSubmit">
          <q-input v-model="email" label="Email" dense outlined class="signin-input" />
          <q-input v-model="password" label="Password" type="password" dense outlined class="signin-input" />
          <q-btn type="submit" label="Sign in" class="signin-btn q-mt-md" />
        </q-form>
        <div class="q-mt-md text-right">
       <router-link to="/sign-up">Sign up</router-link>
        </div>
      </q-card-section>
    </q-card>
  </q-page>
</template>

<script>
export default {
  data() {
    return {
      email: '',
      password: '',
      rememberMe: false,
    };
  },
  methods: {
    handleSubmit() {
      // Handle form submission here
    },
  },
};
</script>