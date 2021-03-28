import { Toolbar, AppBar, Typography, Container } from "@material-ui/core";
export default function Footer() {
  return (
    <AppBar position="static" color="primary">
      <Container maxWidth="md">
        <Toolbar>
          <Typography variant="body1" color="inherit">
            © 2021 AIS
          </Typography>
        </Toolbar>
      </Container>
    </AppBar>
  );
}
