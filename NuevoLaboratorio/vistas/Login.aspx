<%@ Page Title="Home Page" Language="C#"  AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Laboratorio._Default" %>

<!DOCTYPE html>

<html lang="es">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>LaboratorioCaeep</title>
    <link href="../css/loginSignupStyles.css" rel="stylesheet" />
    <!-- ---------------------- logica aplicada en login ----------------------- -->
    <script src="../Scripts/validation.js"></script>


</head>

<body>

    <header class="container">
        <nav>
            <h1 style="color:aliceblue" >Laboratorio</h1>
            <img src="../assets/ministerio.png" alt="logo ministerio">
        </nav>
    </header>

    <div class="container">
        <form runat="server" id="formulario" style="background-color: var(--negro);
    max-width: 50rem;
    margin: 10px 250px 10px 250px;
    padding: 2rem 3rem;
    border-radius: 1rem;
    display: flex;
    flex-direction: column;">
            <div class="form-header">
                <h2 style="color:aliceblue">Laboratorio</h2>
                <p style="color:aliceblue" class="rounded">Login</p>
            </div>

            <label style="color:aliceblue">Email</label>
            <asp:TextBox runat= "server" id="typeEmailX" class="form-control form-control-lg"></asp:TextBox>
            <label style="color:aliceblue">Contraseña</label>
            <asp:TextBox  runat= "server" id="typePasswordX" class="form-control form-control-lg" TextMode="Password" ></asp:TextBox>
             

            <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" OnClientClick="return validar();" />

        </form>

        <div class="ingresarA">
            <a style="color:aliceblue" href="signup.html">¿No tienes una cuenta? Regístrate aquí</a>
        </div>

    </div>

</body>

     <script src="../Scripts/validation.js"></script>

</html>
