<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProtocoloView.aspx.cs" Inherits="NuevoLaboratorio.vistas.ProtocoloView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Protocolo</title>

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
      </div>
    </nav>
  </header>

    <form id="form1" runat="server">
        <div>
      <asp:Button ID="nuevo_Protocolo" runat="server" CssClass="fa-solid fa-pencil" Text="Nuevo Protocolo" OnClick="nuevo_Protocolo_Click" />
      <asp:Button ID="volver" runat="server" CssClass="fa-solid fa-pencil" OnClick="volver_Click" Text="Volver" />
      </div>
    <asp:Panel runat="server" ID="PNL_NuevoProtocolo" Visible="false" >
        
        <div class="jumbotron" style= " background-position: center; opacity: 0,1; background-color: black; "
            height: 100vh >
            <h3 style=" border-color: #000000; color: white"> <asp:Label ID="Label1" runat="server" Text="Nuevo Protocolo" Font-Bold="true" Font-Italic="true"></asp:Label>
            </h3>
            <asp:HiddenField ID="HF_ModificarProtocolo" runat="server" />
            <div class="form-group">
               
                <label style=" color: white; font-weight: bold; font-size: large;" >Nombre Protocolo</label>
                 
                <asp:TextBox runat="server" ID="TB_NombreProtocolo" CssClass="form-control" Width="203px"></asp:TextBox>

                <br />

                <br />
                <asp:Label ID="Inicio" runat="server" Text="FechaInicio " style=" color: white; font-weight: bold; font-size: large;">Fecha de Inicio </asp:Label>
                <br />
                <asp:TextBox ID="TB_FechaInicio" runat="server" TextMode="Date" ></asp:TextBox>
                <asp:Label ID="FechaInicioProtocolo" runat="server" ForeColor="White"></asp:Label>
                <br />
                <br />
                <asp:Label ID="FechaFin" runat="server" Text="FechaFin " style=" color: white; font-weight: bold; font-size: large;">Fecha de Finalización </asp:Label>
                <br />
                <asp:TextBox ID="TB_FechaFin" runat="server" TextMode="Date"></asp:TextBox>
                <asp:Label ID="FechaFinProtocolo" runat="server" ForeColor="White"></asp:Label>
                <br />
                <asp:DropDownList ID="DDL_Responsable" runat="server" >

                </asp:DropDownList>
             


            </div>
            <asp:Button Text="Guardar Protocolo" ID="BTN_Guardar" runat="server" CssClass="btn btn-info"  Visible ="true" OnClick="BTN_Guardar_Click" />
            <asp:Button Text="Cancelar" ID="BTN_Cancelar" runat="server" CssClass="btn btn-default" Visible="true" OnClick="BTN_Cancelar_Click"/>

        </div>
    </asp:Panel>

        <div class="row">

        <asp:GridView ID="GV_Protocolo" runat="server" OnRowCommand="GV_Protocolo_RowCommand"
            AutoGenerateColumns="false"
            CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="100%"
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" EmptyDataText="Sin Registros" >

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

                <asp:TemplateField HeaderText="Responsable">
                    <ItemTemplate>
                        <%# Eval("IdResponsableProtocolo")%>
                    </ItemTemplate>
                </asp:TemplateField> 

                <asp:TemplateField HeaderText="Inicio">
                    <ItemTemplate>
                        <%# Eval("FechaInicio")%>
                    </ItemTemplate>
                </asp:TemplateField> 
                

                  <asp:TemplateField HeaderText="Finaliza">
                    <ItemTemplate>
                        <%# Eval("FechaFin")%>
                    </ItemTemplate>
                </asp:TemplateField> 
                

                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <%# Eval("idEstadoProtocolo")%>
                    </ItemTemplate>
                </asp:TemplateField>                

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="HL_Actividades" title="Actividades" NavigateUrl='<%# string.Format("ActividadView.aspx?id={0}", Eval("Id")) %>' runat="server" Text="Ver Actividades">                                                           
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Puntaje">
                    <ItemTemplate>
                        <%# Eval("Puntaje")%>
                    </ItemTemplate>
                </asp:TemplateField>

     
                <asp:TemplateField>
                    <ItemTemplate>
                  
                        <asp:LinkButton Text="Modificar" ID="BTN_Modificar" runat="server" CssClass="btn btn-warning"
                            CommandName="Modificar" CommandArgument='<%#Eval("Id") %>' ></asp:LinkButton>
                        
                    </ItemTemplate>
                </asp:TemplateField>            
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Text="Eliminar" ID="BTN_Eliminar" runat="server" CssClass="btn btn-danger"
                            CommandName="Eliminar" CommandArgument='<%#Eval("Id") %>' Visible="true" ></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Text="Puntuar" ID="BTN_Puntuar" runat="server" CssClass="btn btn-danger"
                            CommandName="PuntuarProtocol" CommandArgument='<%#Eval("Id") %>' Visible="true" ></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

                               
                
            </Columns>
        </asp:GridView>
   </div>
    </form>
</body>
</html>
