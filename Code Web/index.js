const express = require("express");
const app = express();
const port = process.env.PORT || 3000 ;
const sql = require("mssql") ;
const config = require("./config")

app.use("/", express.static("public"));
app.use(express.json());


// EXECUTE dbo.LoginUser @Email = 'pompi@gmail.com', @Password = 'contrasenia123'

app.post("/LoginJugador", (req, res) => {
  const conn = sql.connect(config, (err) => {
    if (err) console.log(err);
    const request = new sql.Request();
    let query =
      "EXECUTE dbo.LoginUser @Email = '" + req.body.user + "', @Password = '" +req.body.pass+"'";
    console.log(query);
    request.query(query, (err, { recordset }) => {
      if (err) console.log(err);
      console.log(recordset);
      let login = false;
    
       if (
         recordset[0] != null
       ) {
        login = true;
        console.log("siiii") ;
       }
      res.json({
        login: login,
        resultado: recordset[0],
      });
    });
  });
  console.log("Post API");
  console.log(req.body);
  console.log(res.json);
});

//EXECUTE dbo.LoginAdmin @Email = "'" + req.body.user + "'", @Password = "'" + req.body.pass + "'";
app.post("/LoginAdmin", (req, res) => {
  const conn = sql.connect(config, (err) => {
    if (err) console.log(err);
    const request = new sql.Request();
    let query =
    "EXECUTE dbo.LoginAdmin @Email = '" + req.body.user + "', @Password = '" + req.body.pass + "'";
    console.log(query);
    request.query(query, (err, { recordset }) => {
      if (err) console.log(err);
      console.log(recordset[0]);
      let login = false;
      if (
        recordset[0] != null 
      ) {
          login = true ;
          console.log("siisisisisi");
        }
      res.json({
        login: login,
        resultado: recordset[0],
      });
    });
  });
  console.log("Post API");
  console.log(req.body);
  console.log(res.json);
});

app.post("/Ranking", (req, res) => {
  const conn = sql.connect(config, (err) => {
    if (err) console.log(err);
    const request = new sql.Request();
    let query =
    "EXECUTE dbo.ShowRanking";
    console.log(query);
    request.query(query, (err, { recordset }) => {
      if (err) console.log(err);
      console.log(recordset);
      res.json({
        // Name: recordset[req.body.lugar].Name,
        // Position: recordset[req.body.lugar].Position,
        // Played: recordset[req.body.lugar].PlayedTime,
        // OverallScore: recordset[req.body.lugar].OverallScore,
        resultado : recordset ,
      });
    });
  });
  console.log("Post API");
  console.log(res.json);
});

//EXECUTE dbo.Register @Name = "'" + req.body.name + "'", @Email = "'" + req.body.user + "'", @Password = "'" + req.body.pass + "'", @TypeUser = "'" + req.body.type + "'"
app.post("/newUser", (req, res) => {
  const conn = sql.connect(config, (err) => {
    if (err) console.log(err);
    const request = new sql.Request();
    let query =
    "EXECUTE dbo.Register @Name = '" +
    req.body.name +
    "', @Email ='" +
    req.body.user +
    "', @Password = '" +
    req.body.pass +
    "', @TypeUser = " +
    req.body.type ;

    console.log(query);
    request.query(query, (err, result) => {
      if (err) console.log(err);
      res.json(result);
    });
  });
  console.log("Post User");
  console.log(req.body);
});


app.post("/Perfil", (req,res) => {
  const conn = sql.connect(config,(err) => {
    if (err) console.log(err) ;
    const request = new sql.Request();
    let query = "EXECUTE dbo.ShowProfile @Email ='" + req.body.user + "'";

    console.log(query) ;
    request.query(query, (err,{recordset}) => {
      if (err) console.log(err);
      console.log(recordset);
      res.json({
        resultado : recordset[0] ,
      });
    });
  });
  console.log("Post API");
  console.log(res.json);
});

//EXECUTE dbo.InsertActivity @ActivityContent = "'" + req.body. + "'", @UserID = req.body.

// app.post("/linkV", (req,res) => {
//   const conn = sql.connect(config,(err) => { 
//     if (err) console.log(err) ;
//     const request = new sql.Request();
//     let query = "EXECUTE dbo.InsertActivity @ActivityContent = '"+req.body.link+"',  @UserID ="+req.body.id ;
//     console.log(query) ;
//     request.query(query, (err,{recordset}) => {
//       if (err) console.log(err);
//       console.log(recordset);
//       res.json({
//         resultado : recordset ,
//       });
//     });
//   });
//   console.log("Post API");
//   console.log(res.json);
// });

//EXECUTE dbo.UpdateUserInfo @UserID = "'" + req.body.id + "'", @PhoneNum = "'" + req.body. + "'", @UserWeb = "'" + req.body. + "'", @UserGit = "'" + req.body. + "'", @UserTw = "'" + req.body. + "'", @UserIg = "'" + req.body. + "'", @UserFb = "'" + req.body. + "'";

app.put("/updateUser", (req,res) => { 
  const conn = sql.connect(config,(err) => { 
    if (err) console.log(err) ;
    const request = new sql.Request();
    let query = "EXECUTE dbo.UpdateUserInfo @UserID = " + req.body.id + ", @Age ="+req.body.Age+
    ", @PhoneNum = '"+req.body.PhoneNum+"', @UserWeb = '"+req.body.UserWeb+"',@UserGit = '"+
    req.body.UserGit+"', @UserTw = '"+req.body.UserTw+"', @UserIg = '"+req.body.UserIg+"', @UserFb = '"+req.body.UserFb+"'";
    console.log(query) ;
    request.query(query, (err,{recordset}) => {
      if (err) console.log(err);
      console.log(recordset);
      res.json({
        resultado : recordset ,
      });
    });
  });
  console.log("PUT API");
  console.log(res.json);
});
// EXECUTE dbo.Logout @Email = "'" + req.body.user + "'";
//Logout
app.put("/LogOut", (req,res) => {
  const conn = sql.connect(config,(err) => {
    if (err) console.log(err) ;
    const request = new sql.Request();
    let query = "EXECUTE dbo.Logout @Email ='" + req.body.user + "'";

    console.log(query) ;
    request.query(query, (err,{recordset}) => {
      if (err) console.log(err);
      console.log(recordset);
      res.json({
        resultado : recordset ,
      });
    });
  });
  console.log("Post API");
  console.log(res.json);
});


app.put("/Avatar", (req,res) => { 
  const conn = sql.connect(config,(err) => { 
    if (err) console.log(err) ;
    const request = new sql.Request();
    let query = "EXECUTE dbo.SaveAvatar @UserID =" + req.body.id +", @SkinColor = '"
    + req.body.SkinColor + "', @Eyes = '" + req.body.Eyes + 
    "', @Eyebrows = '" + req.body.Eyebrows + "', @Mouth = '" 
    + req.body.Mouth + "', @HairStyle = '" + req.body.HairStyle 
    + "', @HairColor = '" + req.body.HairColor + "', @FacialHair = '" + req.body.FacialHair + "', @Clothes = '" + req.body.Clothes + "', @FabricColor = '" + req.body.FabricColor + 
    "', @Glasses = '" + req.body.Glasses + "', @GlassesOpac = '" + req.body.GlassesOpac 
    + "', @Accesories = '" + req.body.Accesories + "', @Tattoos = '" + req.body.Tattoos + "', @BackgroundColor = '" + req.body.BackgroundColor + "'";
    console.log(query) ;

    request.query(query, (err,{recordset}) => {
      if (err) console.log(err);
      console.log(recordset);
      res.json({
        resultado : recordset ,
      });
    });
  });
  console.log("Put API");
  console.log(res.json);
});

app.get("/decision", (req, res) => {
  const conn=sql.connect(config,(err)=> {
    if(err) console.log(err);
    // Obtener decisiones de la base de datos
    const request=new sql.Request();
    console.log("Execute");
    // Regresar decisiones como resultado
    request.query("SELECT * FROM dbo.[DECISIONES]",(err,{recordset}) => {
      if(!err){
        //console.log(recordset);
        res.json({
          decisions: recordset
        });
      } else{
        console.log(err);
      }
    });
  });
});

//borrar usuario
app.delete("/delete", (req,res) => {
  const conn = sql.connect(config, (err) => {
    if (err) console.log(err);
    const request = new sql.Request();
    let query = "EXECUTE dbo.DeleteUser @Email = '"+ req.body.user + "', @Password = '" + req.body.pass + "'";
    console.log(query);
    request.query(query, (err, result) => { 
      if (err) console.log(err);
      res.json(result);
    });
  });
  console.log("Delete User");
  console.log(req.body);
});


//Active Users
app.post("/activeUsers", (req, res) => {
  const conn = sql.connect(config,(err) => {
    if (err) console.log(err) ;
    const request = new sql.Request();
    let query = "EXECUTE dbo.ActiveUsers" ;
    console.log(query) ;
    request.query(query, (err,{recordset}) => {
      if (err) console.log(err);
      console.log(recordset[0] );
      res.json({
        resultado : recordset[0] ,
      });
    });
  });
  console.log("Post API");
  console.log(res.json);
});

//Inactive Users
app.post("/inActiveUsers", (req, res) => {
  const conn = sql.connect(config,(err) => {
    if (err) console.log(err) ;
    const request = new sql.Request();
    let query = "EXECUTE dbo.InactiveUsers" ;
    console.log(query) ;
    request.query(query, (err,{recordset}) => {
      if (err) console.log(err);
      console.log(recordset[0] );
      res.json({
        resultado : recordset[0] ,
      });
    });
  });
  console.log("Post API");
  console.log(res.json);
});

//Show tasks
app.post("/showTask", (req, res) => {
  const conn = sql.connect(config,(err) => {
    if (err) console.log(err) ;
    const request = new sql.Request();
    let query = "EXECUTE dbo.ShowTasks" ;
    console.log(query) ;
    request.query(query, (err,{recordset}) => {
      if (err) console.log(err);
      console.log(recordset);
      res.json({
        resultado : recordset ,
      });
    });
  });
  console.log("Post API");
  console.log(res.json);
});

//Show Activity
app.post("/showActivity", (req, res) => {
  const conn = sql.connect(config,(err) => {
    if (err) console.log(err) ;
    const request = new sql.Request();
    let query = "EXECUTE dbo.ShowActivity" ;
    console.log(query) ;
    request.query(query, (err,{recordset}) => {
      if (err) console.log(err);
      console.log(recordset);
      res.json({
        resultado : recordset ,
      });
    });
  });
  console.log("Post API");
  console.log(res.json);
});

//Show Game Activity
app.post("/showGameActivity", (req, res) => {
  const conn = sql.connect(config,(err) => {
    if (err) console.log(err) ;
    const request = new sql.Request();
    let query = "EXECUTE dbo.ShowGActivity" ;
    console.log(query) ;
    request.query(query, (err,{recordset}) => {
      if (err) console.log(err);
      console.log(recordset);
      res.json({
        resultado : recordset ,
      });
    });
  });
  console.log("Post API");
  console.log(res.json);
});

// Obtener decisión basada en el ID
app.get("/decision/:ID", (req, res) => {
  const conn=sql.connect(config,(err)=> {
    if(err) console.log(err);
    // Obtener decisiones de la base de datos
    const request=new sql.Request();
    console.log("Execute");
    console.log(req.params.ID);
    // Regresar decisiones como resultado
    request.query("SELECT * FROM dbo.[DECISIONES] WHERE DECISIONESID = "+[req.params.ID],(err,{recordset}) => {
      if(!err){
        console.log(recordset);
        console.log("-----------------------------------");
        res.json({
          decisions: recordset
        });
      } else{
        console.log(err);
      }
    });
  });
});

// Actualizar decisión basada en el ID
app.put("/decision/:ID", (req, res) => {
  const conn=sql.connect(config,(err)=> {
    if(err) console.log(err);
    // Obtener decisiones de la base de datos
    const request=new sql.Request();
    console.log("Execute");
    //console.log(req.body);
    console.log("UPDATE dbo.[DECISIONES] SET PlayedTime="+req.body.PlayedTime
    +", Level="+req.body.Level
    +", Decisions="+req.body.Decisions
    +", Score="+req.body.Score+" WHERE DECISIONESID="+idAux);
    var idAux= [req.params.ID];
    let qry= "UPDATE dbo.[DECISIONES] SET PlayedTime="+parseFloat(req.body.PlayedTime)
      +", Level="+parseInt(req.body.Level)
      +", Decisions="+parseInt(req.body.Decisions)
      +", Score="+parseInt(req.body.Score)+" WHERE DECISIONESID="+idAux;
    // Regresar decisiones como resultado
    request.query(qry,(err,result) => {
      if (err) console.log(err);
      res.json(result);
    });
  });
});

app.get("/preguntados", (req, res) => {
  const conn=sql.connect(config,(err)=> {
    if(err) console.log(err);
    // Obtener decisiones de la base de datos
    const request=new sql.Request();
    console.log("Execute");
    // Regresar decisiones como resultado
    request.query("SELECT * FROM dbo.[QUIZZ]",(err,{recordset}) => {
      if(!err){
        //console.log(recordset);
        res.json({
          decisions: recordset
        });
      } else{
        console.log(err);
      }
    });
  });
});

// Obtener decisión basada en el ID
app.get("/preguntados/:ID", (req, res) => {
  const conn=sql.connect(config,(err)=> {
    if(err) console.log(err);
    // Obtener decisiones de la base de datos
    const request=new sql.Request();
    console.log("Execute");
    console.log(req.params.ID);
    // Regresar decisiones como resultado
    request.query("SELECT * FROM dbo.[QUIZZ] WHERE QUIZZID = "+[req.params.ID],(err,{recordset}) => {
      if(!err){
        console.log(recordset);
        console.log("-----------------------------------");
        res.json({
          preguntados: recordset
        });
      } else{
        console.log(err);
      }
    });
  });
});

// Actualizar decisión basada en el ID
app.put("/preguntados/:ID", (req, res) => {
  const conn=sql.connect(config,(err)=> {
    if(err) console.log(err);
    // Obtener decisiones de la base de datos
    const request=new sql.Request();
    console.log("Execute");
    //console.log(req.body);
    console.log("UPDATE dbo.[QUIZZ] SET Score="+req.body.Score+" WHERE QUIZZID="+[req.params.ID]);
    let qry= "UPDATE dbo.[QUIZZ] SET Score="+req.body.Score+" WHERE QUIZZID="+[req.params.ID];
    // Regresar decisiones como resultado
    request.query(qry,(err,result) => {
      if (err) console.log(err);
      res.json(result);
    });
  });
});

app.listen(port, () => {
  console.log(`Example app listening at http://localhost:${port}`)
})

