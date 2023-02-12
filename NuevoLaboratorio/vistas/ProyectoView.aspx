<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProyectoView.aspx.cs" Inherits="NuevoLaboratorio.vistas.ProyectoView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Laboratorio</title>

 <link href="../css/loginSignupStyles.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            display: block;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: #212529;
            background-clip: padding-box;
            -webkit-appearance: none;
            -moz-appearance: none;
            appearance: none;
            border-radius: .375rem;
            transition: none;
            border: 1px solid #ced4da;
            background-color: #fff;
        }
    </style>
</head>
<body>
    <script src="../assets/pluggins/dist/sweetalert2.all.js"></script>

     <header class="container">
    <nav>
      <h1 style="color:aliceblue" >Laboratorio</h1>

      <div class="user-info">
        <div class="user-image"></div>
          

        <%--<button id="closeApp"><i class="fa-solid fa-right-from-bracket"></i> Cerrar sesión</button>--%>
      </div>
    </nav>
  </header>

    <form id="form1" runat="server">
        <asp:Button Text="Cerrar Sesión" runat="server" ID="logout" OnClick="logout_Click"/>
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div>
      <asp:Button ID="nuevo_Proyecto" runat="server" CssClass="fa-solid fa-pencil" Text="Nuevo Proyecto" OnClick="nuevo_Proyecto_Click"/>
      </div>

        <asp:Panel runat="server" ID="PNL_NuevoProyecto" Visible="false" >
        
        <div class="jumbotron" style= " background-position: center; opacity: 0,1; background-color: black; "
            height: 100vh >
            <h3 style=" border-color: #000000; color: white"> <asp:Label ID="Label1" runat="server" Text="Nuevo Proyecto" Font-Bold="true" Font-Italic="true"></asp:Label>
            </h3>
            <asp:HiddenField ID="HF_Modificar" runat="server" />
            <div class="form-group">
               
                <label style=" color: white; font-weight: bold; font-size: large;" >Nombre Proyecto</label>
                 
                <asp:TextBox runat="server" ID="TB_NombreProyecto" CssClass="auto-style1" Width="515px"></asp:TextBox>
                <br />
                <br />


                <br />
                <asp:Label ID="FechaFin" runat="server" Text="FechaFin " style=" color: white; font-weight: bold; font-size: large;">Fecha Finalización </asp:Label>
                &nbsp;<br />
                <br />
                <asp:TextBox ID="TB_FechaFin" runat="server" TextMode="Date" Width="157px"></asp:TextBox>

                <asp:Label ID="FechaFinMostrar" runat="server" ForeColor="white"> </asp:Label> 
 
                <br />
                <br />
                <asp:Label ID="LB_Observaciones" runat="server" Text="Observaciones" style=" color: white; font-weight: bold; font-size: large;"> Observaciones</asp:Label>
                <br />
                <br />
                <asp:TextBox ID="TB_Observaciones" runat="server" Height="90px" Width="620px"></asp:TextBox>

                <br />
                <asp:Label ID="LB_Responsable" runat="server" Text="Responsable" style=" color: white; font-weight: bold; font-size: large;">Responsable</asp:Label>
                <br />

                <asp:DropDownList ID="DDL_Responsable" runat="server" >

                </asp:DropDownList>
                <br />


            </div>
            <asp:Button Text="Guardar Proyecto" ID="BTN_Guardar" runat="server" CssClass="btn btn-info"  Visible ="true" OnClick="BTN_Guardar_Click"  />
      
            <asp:Button Text="Cancelar" ID="BTN_Cancelar" runat="server" CssClass="btn btn-light" Visible="true" OnClick="BTN_Cancelar_Click" />

        </div>
    </asp:Panel>


        <div class="row">

        <asp:GridView ID="GV_Proyecto" runat="server" OnRowCommand="GV_Proyecto_RowCommand"
            AutoGenerateColumns="false"
            CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="100%"
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" EmptyDataText="Sin Registros" RowCommand="GV_Proyecto_RowCommand">

            <FooterStyle BackColor="#CCCC99" ForeColor="Black"></FooterStyle>

            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White"></HeaderStyle>

            <PagerStyle HorizontalAlign="Right" BackColor="White" ForeColor="Black"></PagerStyle>

            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

            <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>

            <SortedAscendingHeaderStyle BackColor="#4B4B4B"></SortedAscendingHeaderStyle>

            <SortedDescendingCellStyle BackColor="#E5E5E5"></SortedDescendingCellStyle>

            <SortedDescendingHeaderStyle BackColor="#242121"></SortedDescendingHeaderStyle>
            <Columns>
                
                <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate>
                        <%# Eval("Nombre")%>
                    </ItemTemplate>
                </asp:TemplateField>
                

                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <%# Eval("EstadoProyecto")%>
                    </ItemTemplate>
                </asp:TemplateField> 

                <asp:TemplateField HeaderText="Responsable">
                    <ItemTemplate>
                        <%# Eval("Responsable")%>
                    </ItemTemplate>
                </asp:TemplateField> 

                <asp:TemplateField HeaderText="Fecha Finalización">
                    <ItemTemplate>
                        <%# Eval("FechaFin")%>
                    </ItemTemplate>
                </asp:TemplateField> 

                 

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="HL_Protocolos" title="Protocolos" NavigateUrl='<%# string.Format("ProtocoloView.aspx?id={0}", Eval("Id")) %>' 
                            PostBackUrl="~/ProyectoView.aspx" runat="server"> Ver Protocolos </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Observaciones">
                    <ItemTemplate>
                        <%# Eval("Observaciones")%>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField>
                    <ItemTemplate>
                  
                        <asp:LinkButton Text="Modificar" ID="BTN_Modificar" runat="server" Visible ='<%# this.enableButton(Eval("Id").ToString()) %>' CssClass="btn btn-warning"
                            CommandName="Modificar" CommandArgument='<%#Eval("Id") %>' ></asp:LinkButton>
                        
                    </ItemTemplate>
                </asp:TemplateField>            
               

                <asp:TemplateField>
                    <ItemTemplate>
                  
                        <asp:LinkButton Text="Rechazar" ID="BTN_Rechazar" runat="server" Visible ='<%# this.enableButton(Eval("Id").ToString()) %>' CssClass="btn btn-danger"
                            CommandName="Rechazar" CommandArgument='<%#Eval("Id") %>' ></asp:LinkButton>
                        
                    </ItemTemplate>
                </asp:TemplateField>  
                
                <asp:TemplateField>
                    <ItemTemplate>
                  
                        <asp:LinkButton Text="Iniciar" ID="BTN_Iniciar" runat="server" Visible ='<%# this.enableButton(Eval("Id").ToString()) %>' CssClass="btn btn-dark"
                            CommandName="Iniciar" CommandArgument='<%#Eval("Id") %>' ></asp:LinkButton>
                        
                    </ItemTemplate>
                </asp:TemplateField> 



                 <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Text="Eliminar" ID="BTN_Eliminar" runat="server" Visible ='<%# this.enableButton(Eval("Id").ToString()) %>' CssClass="btn btn-danger"
                            CommandName="Eliminar" CommandArgument='<%#Eval("Id") %>' ></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField>
                    <ItemTemplate>
                  
                        <asp:LinkButton Text="Finalizar" ID="BTN_Finalizar" runat="server" Visible ='<%# this.enableButton(Eval("Id").ToString()) %>' CssClass="btn btn-info"
                            CommandName="Finalizar" CommandArgument='<%#Eval("Id") %>' ></asp:LinkButton>
                        
                    </ItemTemplate>
                </asp:TemplateField> 

     
            </Columns>
        </asp:GridView>
        </div>


    </form>
</body>
</html>
