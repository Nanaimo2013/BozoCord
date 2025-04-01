import React from 'react';
import { Container, Title, Text, Button, Group } from '@mantine/core';
import { Link } from 'react-router-dom';

const Home: React.FC = () => {
  return (
    <Container size="lg">
      <Title order={1} align="center" mt={50}>
        Welcome to BozoCord
      </Title>
      <Text align="center" size="lg" mt="md">
        Your next-generation communication platform
      </Text>
      <Group position="center" mt={30}>
        <Button component={Link} to="/login" size="lg">
          Login
        </Button>
        <Button component={Link} to="/register" variant="outline" size="lg">
          Register
        </Button>
      </Group>
    </Container>
  );
};

export default Home; 