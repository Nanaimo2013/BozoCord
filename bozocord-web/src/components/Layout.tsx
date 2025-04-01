import React from 'react';
import { AppShell, Navbar, Header, Text, MediaQuery, Burger, useMantineTheme, useMantineColorScheme } from '@mantine/core';
import { Link, useLocation } from 'react-router-dom';

interface LayoutProps {
  children: React.ReactNode;
}

const Layout: React.FC<LayoutProps> = ({ children }) => {
  const theme = useMantineTheme();
  const [opened, setOpened] = React.useState(false);
  const location = useLocation();
  const { colorScheme, toggleColorScheme } = useMantineColorScheme();

  return (
    <AppShell
      styles={{
        main: {
          background: colorScheme === 'dark' ? theme.colors.dark[8] : theme.colors.gray[0],
        },
      }}
      navbarOffsetBreakpoint="sm"
      navbar={
        <Navbar p="md" hiddenBreakpoint="sm" hidden={!opened} width={{ sm: 200, lg: 300 }}>
          <Navbar.Section>
            <Text size="xl" weight={700} mb="md">BozoCord</Text>
            <Link to="/" style={{ textDecoration: 'none', color: 'inherit' }}>
              <Text color={location.pathname === '/' ? 'blue' : 'inherit'}>Home</Text>
            </Link>
            <Link to="/login" style={{ textDecoration: 'none', color: 'inherit' }}>
              <Text color={location.pathname === '/login' ? 'blue' : 'inherit'}>Login</Text>
            </Link>
            <Link to="/register" style={{ textDecoration: 'none', color: 'inherit' }}>
              <Text color={location.pathname === '/register' ? 'blue' : 'inherit'}>Register</Text>
            </Link>
          </Navbar.Section>
        </Navbar>
      }
      header={
        <Header height={70} p="md">
          <div style={{ display: 'flex', alignItems: 'center', height: '100%' }}>
            <MediaQuery largerThan="sm" styles={{ display: 'none' }}>
              <Burger
                opened={opened}
                onClick={() => setOpened((o) => !o)}
                size="sm"
                color={theme.colors.gray[6]}
                mr="xl"
              />
            </MediaQuery>
            <Text size="xl" weight={700}>BozoCord</Text>
          </div>
        </Header>
      }
    >
      {children}
    </AppShell>
  );
};

export default Layout; 